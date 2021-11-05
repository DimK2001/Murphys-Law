using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTrigger : Trigger
{
    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            player.GetComponent<Player>().PlayAnimation(AnimationName);
            player.GetComponent<Rigidbody>().velocity = Vector2.zero;
        }
    }
}
