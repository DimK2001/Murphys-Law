using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTrigger : Trigger
{
    public Item Item;
    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            //player.GetComponent<Player>().PlayAnimation(AnimationName);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            FindObjectOfType<Inventory>().AddItem((int)Item);
            Destroy(gameObject);
        }
    }
}
