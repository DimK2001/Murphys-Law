using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    public string[] Text;
    int i = 0;
    private void Start()
    {
        Activate();
    }
    public void Activate()
    {
        StopCoroutine(Deactivate());
        i = 0;
        GetComponentInChildren<Text>().text = Text[i];
        gameObject.SetActive(true);
        i++;
        StartCoroutine(Deactivate());
    }
    public IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(3);
        if (i < Text.Length)
        {
            GetComponentInChildren<Text>().text = Text[i];
            i++;
            StartCoroutine(Deactivate());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
