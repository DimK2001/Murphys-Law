using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStairsTrigger : TeleportTrigger
{
    public GameObject Colliders;

    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            player.transform.position = startOffsetPlayerPos.position;
            //player.GetComponent<Player>().PlayAnimation(AnimationName, this);
            if (Colliders.activeInHierarchy)
            {
                Colliders.SetActive(false);
            }
            else
            {
                Colliders.SetActive(true);
            }
            TeleportToEnd();
            StartCoroutine(Stop());
        }
    }
}
