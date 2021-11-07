using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Animator animator;
    public GameObject endScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.GetComponent<Player>().enabled = false;
            collision.GetComponent<Animator>().enabled = false;
            animator.SetTrigger("Move");
            StartCoroutine(WaitBeforeEnd());
        }
    }

    public IEnumerator WaitBeforeEnd()
    {
        yield return new WaitForSeconds(5f);
        endScreen.SetActive(true);
    }
}
