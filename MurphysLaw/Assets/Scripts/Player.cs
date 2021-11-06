using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10;
    public GameObject Buttons;

    private Rigidbody2D rb;
    private Collider2D col;
    private Animator anim;

    private TeleportTrigger nowTp;

    public bool onStairs;
    private void Start()
    {
        onStairs = false;
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
        
        if (col.IsTouchingLayers(1 << 3))//Проверка, что игрок стоит на полу (слой 3)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(Speed * horizontaMoveInput, rb.velocity.y);
            anim.SetBool("Walking", true);
        }
        if (horizontaMoveInput == 0)
        {
            anim.SetBool("Walking", false);
        }

        /*
        if (onStairs && Input.GetButtonDown("Interact"))
        {
            onStairs = false;
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y, 0f);
        }*/

    }

    private void Update()
    {
        UpOnStairs();
    }

    public void UpOnStairs()
    {
        if (onStairs)
        {
            float verticalMoveInput = Input.GetAxis("Vertical");
            rb.isKinematic = true;
            rb.velocity = new Vector2(rb.velocity.x, Speed * verticalMoveInput);
            // Тут должна быть анимация карабкания
            rb.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!onStairs)
        {
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
}
