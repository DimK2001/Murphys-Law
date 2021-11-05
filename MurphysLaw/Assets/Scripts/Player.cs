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
    private void Start()
    {
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
            transform.localScale = new Vector3(1, 1 ,1);
        }
        if (col.IsTouchingLayers(1 << 3))//Проверка, что игрок стоит на полу (слой 3)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(Speed * horizontaMoveInput, rb.velocity.y);
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
