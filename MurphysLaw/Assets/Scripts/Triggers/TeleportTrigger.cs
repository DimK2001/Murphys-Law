using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : Trigger
{
    public Transform startOffsetPlayerPos;
    public Transform endOffsetPlayerPos;
    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            player.transform.position = startOffsetPlayerPos.position;
            player.GetComponent<Player>().PlayAnimation(AnimationName, this);
        }
    }
    public void TeleportToEnd()
    {
        player.transform.position = endOffsetPlayerPos.position;
    }
}
