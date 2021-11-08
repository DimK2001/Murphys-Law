using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float Speed = 10;
    public GameObject Buttons;

    public AudioClip Stair;
    public AudioClip Walk;

    private Rigidbody2D rb;
    private Collider2D col;
    private Animator anim;

    private TeleportTrigger nowTp;

    public bool onStairs;
    public float directX;
    public bool canWalk;
    private void Start()
    {
        onStairs = false;
        canWalk = true; 
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float horizontaMoveInput = Input.GetAxis("Horizontal");
        
        if (horizontaMoveInput < 0 && transform.localScale.x == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontaMoveInput > 0 && transform.localScale.x == -1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (col.IsTouchingLayers(1 << 3) && canWalk)//Проверка, что игрок стоит на полу (слой 3)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(Speed * horizontaMoveInput, rb.velocity.y);
            anim.SetBool("Walking", true);
            /*
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().clip = Walk;
                GetComponent<AudioSource>().Play();
            }*/
        }
        if (horizontaMoveInput == 0)
        {
            anim.SetBool("Walking", false);
            //GetComponent<AudioSource>().Stop();
        }

        /*
        if (onStairs && Input.GetButtonDown("Interact"))
        {
            onStairs = false;
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y, 0f);
        }*/
        UpOnStairs();

    }

    public void UpOnStairs()
    {
        if (onStairs)
        {
            float verticalMoveInput = Input.GetAxis("Vertical");
            rb.isKinematic = true;
            rb.velocity = new Vector2(rb.velocity.x, Speed * verticalMoveInput);
            if (verticalMoveInput != 0)
            {
                anim.SetBool("Climbing", true);
                /*
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    GetComponent<AudioSource>().clip = Stair;
                    GetComponent<AudioSource>().Play();
                }*/
            }
            else
            {
                anim.SetBool("Climbing", false);
                //GetComponent<AudioSource>().Stop();
            }
            
            rb.transform.localScale = new Vector3(directX, 1, 1);
        }
        else if (!onStairs)
        {
            anim.SetBool("Climbing", false);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
            }
        }
    }

    public void PlayAnimation(string _name)
    {
        anim.Play(_name);
    }
    public void PlayAnimation(string _name, TeleportTrigger _tp)
    {
        anim.Play(_name);
        nowTp = _tp;
    }
    public void TeleportPlayer()
    {
        nowTp.TeleportToEnd();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
