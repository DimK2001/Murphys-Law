using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10;


    private Rigidbody2D rb;
    private Collider2D col;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    private void FixedUpdate()
    {
        float horizontaMoveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Speed * horizontaMoveInput, rb.velocity.y);
        if (horizontaMoveInput < 0)
        {
            //Проиграть анимку движения вправо  
        }
        else if (horizontaMoveInput > 0)
        {
            //Анимка движения влево
        }
        else if (col.IsTouchingLayers(3))//Проверка, что игрок стоит на полу (слой 3)
        {
            rb.velocity = Vector2.zero;//не обязательная хуйня, а просто чтоб не багало
        }
    }
}
