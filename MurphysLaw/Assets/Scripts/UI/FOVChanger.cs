using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVChanger : MonoBehaviour
{
    public Camera mainCamera;
    public Camera roomCamera;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainCamera.gameObject.SetActive(false);
            roomCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainCamera.gameObject.SetActive(true);
            roomCamera.gameObject.SetActive(false);
        }
    }
}
