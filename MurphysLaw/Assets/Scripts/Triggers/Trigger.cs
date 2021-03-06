using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Glow;
    public string AnimationName;

    public bool playerInside = false;
    protected GameObject player;
    protected GameObject ButtonImg;

    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            playerInside = false;
            player.GetComponent<Player>().PlayAnimation(AnimationName);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Glow.gameObject.SetActive(true);
            ButtonImg = collision.GetComponent<Player>().Buttons;
            ButtonImg.SetActive(true);
      
            ButtonImg.gameObject.SetActive(true);
            player = collision.gameObject;
            playerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Glow.gameObject.SetActive(false);
            ButtonImg.gameObject.SetActive(false);
            playerInside = false;
            //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
