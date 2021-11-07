using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntreactiveObject : MonoBehaviour
{
    public bool Interactable = true;

    protected Inventory inventory;
    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    public virtual void Interact(GameObject _player) { }
    public virtual void UnInteract(GameObject _player) { }
}
