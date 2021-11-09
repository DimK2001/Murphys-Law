using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTrigger : Trigger
{
    public Transform onStairsPos;
    public Transform groundPos;
    
    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            player.GetComponent<Player>().onStairs = true;
            player.transform.position = onStairsPos.position; // залезает на лестницу
            //player.GetComponent<Player>().PlayAnimation(AnimationName, this);
            player.GetComponent<Player>().directX = transform.parent.localScale.x;
            
            StartCoroutine(Stop());
        }

        if (playerInside)
        {
            if (player.GetComponent<Player>().onStairs && playerHasExit)
            {
                player.transform.position = groundPos.transform.position; // перенос игрока с лестницы на поверхность 
                player.GetComponent<Player>().onStairs = false;
                
            }
            playerHasExit = false;
        }
       
    }
    
    IEnumerator Stop()
    {
        yield return new WaitForFixedUpdate();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
