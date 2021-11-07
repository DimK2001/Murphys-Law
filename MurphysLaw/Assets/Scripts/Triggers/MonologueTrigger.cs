using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger : Trigger
{
    public GameObject Monologue;
    public string[] Text;
    private void Update()
    {
        if (playerInside && Input.GetButtonDown("Interact"))
        {
            Monologue.GetComponent<Dialog>().Text = Text;
            Monologue.GetComponent<Dialog>().Activate();
        }
    }
}
