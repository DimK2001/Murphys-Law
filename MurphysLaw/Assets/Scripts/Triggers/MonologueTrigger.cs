using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger : Trigger
{
    public GameObject Monologue;
    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            Monologue.SetActive(true);
        }
        else if(!playerInside && Monologue.activeInHierarchy)
        {
            Monologue.SetActive(false);
        }
    }
}
