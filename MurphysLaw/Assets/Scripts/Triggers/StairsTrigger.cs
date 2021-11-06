using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : Trigger
{
    public Transform startOffsetPlayerPos;
    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            player.GetComponent<Player>().onStairs = true;
            player.transform.position = startOffsetPlayerPos.position; // залезает на лестницу
            //player.GetComponent<Player>().PlayAnimation(AnimationName, this);
            StartCoroutine(Stop());
        }
        
        if (playerInside)
        {
            if (player.GetComponent<Player>().onStairs)
            {
                Glow.SetActive(false);
                ButtonImg.SetActive(false);
            }
            else
            {
                Glow.SetActive(true);
                ButtonImg.SetActive(true);
            }
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitForFixedUpdate();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
