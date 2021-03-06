using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : IntreactiveObject
{
    public GameObject Green;
    public GameObject Both;
    public GameObject Opened;
    public GameObject Lid;
    public GameObject Collider;
    public GameObject BusStop;
    public override void Interact(GameObject _player)
    {
        //GetComponent<Trigger>().playerInside = false;
        if (Green.activeInHierarchy)
        {
            Green.SetActive(false);
        }
        if (Input.GetButtonDown("Interact") && inventory.itemsInInventory.Find(x => x.GetComponent<UIItem>().Type == Item.screwdriver) && Lid.activeInHierarchy)
        {
            GetComponent<InteractiveTrigger>().Deactivate();
            //Collider.SetActive(false);
            Lid.SetActive(false);
            Opened.SetActive(true);
            Both.SetActive(true);
            Green.SetActive(false);
            Interactable = false;
            BusStop.GetComponent<BusStop>().Traffic();
            inventory.DelItem(inventory.itemsInInventory.FindIndex(x => x.GetComponent<UIItem>().Type == Item.screwdriver));
        }
    }
    public override void UnInteract(GameObject _player)
    {
        if (!Green.activeInHierarchy)
        {
            Green.SetActive(true);
        }
    }
}
