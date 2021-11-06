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
            //player.GetComponent<Player>().PlayAnimation(AnimationName, this);
            TeleportToEnd();
            StartCoroutine(Stop());
        }
    }
    public void TeleportToEnd()
    {
        player.transform.position = endOffsetPlayerPos.position;
    }

    public IEnumerator Stop()
    {
        //yield return new WaitForSeconds(0.03f);
        yield return new WaitForFixedUpdate();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

}
