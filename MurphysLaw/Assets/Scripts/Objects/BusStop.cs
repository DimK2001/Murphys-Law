using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop : IntreactiveObject
{
    private Animator anim;
    
    public override void Interact(GameObject _player)
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Away", true);
    }
    public void Traffic()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("Traffic");
    }
    public override void UnInteract(GameObject _player)
    {
        anim.SetBool("Away", false);
    }
}