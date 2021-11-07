using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffTrigger : MonoBehaviour
{
    public GameObject Colliders;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Colliders.activeInHierarchy)
            {
                Colliders.SetActive(false);
            }/*
            else
            {
                Colliders.SetActive(true);
            }*/
        }
    }
}
