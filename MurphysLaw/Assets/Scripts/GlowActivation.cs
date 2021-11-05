using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowActivation : MonoBehaviour
{
    Transform glow;
    private void Start()
    {
        glow = transform.GetChild(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            glow.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            glow.gameObject.SetActive(false);
        }
    }
}
