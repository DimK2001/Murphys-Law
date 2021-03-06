using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfStairsTrigger : MonoBehaviour
{
    public Transform endOffsetPlayerPos;
    public GameObject Colliders;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>().onStairs) // ???? ?????? ?? ????????
            {
                collision.transform.position = endOffsetPlayerPos.position; // ??????? ?????? ? ???????? ?? ??????????? 
                collision.GetComponent<Player>().onStairs = false;
                /*
                if (Colliders.activeInHierarchy)
                {
                    Colliders.SetActive(false);
                }
                else
                {
                    Colliders.SetActive(true);
                }*/
                StartCoroutine(Stop(collision));
            }
        }
    }

    IEnumerator Stop(Collider2D collision)
    {
        //yield return new WaitForSeconds(0.03f);
        yield return new WaitForFixedUpdate();
        collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
