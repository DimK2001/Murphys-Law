using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTrigger : Trigger
{
    private void Update()
    {
        if (playerInside)
        {
            GetComponent<IntreactiveObject>().Interact(player);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Glow.gameObject.SetActive(false);
            ButtonImg.gameObject.SetActive(false);
            playerInside = false;
            GetComponent<IntreactiveObject>().UnInteract(player);
        }
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GetComponent<IntreactiveObject>().Interactable)
        {
            Glow.gameObject.SetActive(true);
            ButtonImg = collision.GetComponent<Player>().Buttons;
            ButtonImg.SetActive(true);

            ButtonImg.gameObject.SetActive(true);
            player = collision.gameObject;
            playerInside = true;
        }
    }
    public void Deactivate()
    {
        Glow.gameObject.SetActive(false);
        ButtonImg.gameObject.SetActive(false);
        playerInside = false;
        GetComponent<IntreactiveObject>().UnInteract(player);
        this.enabled = false;
    }
}
