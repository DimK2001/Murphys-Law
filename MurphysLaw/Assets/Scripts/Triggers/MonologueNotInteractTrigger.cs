using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueNotInteractTrigger : MonoBehaviour
{
    public GameObject Monologue;
    public string[] Text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Monologue.GetComponent<Dialog>().Text = Text;
            Monologue.GetComponent<Dialog>().Activate();
            gameObject.SetActive(false);
        }
    }
}
