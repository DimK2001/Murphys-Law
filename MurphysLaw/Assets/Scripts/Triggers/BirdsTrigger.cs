using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsTrigger : MonoBehaviour
{
    public GameObject oldBirds;
    public GameObject newBirds;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            oldBirds.SetActive(false);
            newBirds.SetActive(true);
            other.transform.position = transform.position;
            other.transform.localScale = new Vector3(1, 1, 1);
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponent<Player>().canWalk = false;
            other.GetComponent<Player>().GetComponent<Animator>().SetTrigger("Birds");
        }
    }
}
