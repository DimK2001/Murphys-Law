using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowActivation : MonoBehaviour
{
    public GameObject Glow;


    public void ActivateGlow()
    {
        Glow.gameObject.SetActive(true);
    }
    public void DeactivateGlow()
    {
        Glow.gameObject.SetActive(false);
    }
}
