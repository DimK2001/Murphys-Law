using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Glow;
    public GameObject ButtonImg;
    public string AnimationName;

    protected bool playerInside = false;
    protected GameObject player;

    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            player.GetComponent<Player>().PlayAnimation(AnimationName);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Glow.gameObject.SetActive(true);
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
        }
    }
}
