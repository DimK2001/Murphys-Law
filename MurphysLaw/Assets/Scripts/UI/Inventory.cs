using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public GameObject[] ItemObjects;
    //[HideInInspector]
    public List<GameObject> itemsInInventory = new List<GameObject>();
    public void AddItem(int _num)
    {
        itemsInInventory.Add(Instantiate(ItemObjects[_num], transform));
    }
    public void DelItem(int _num)
    {
        GameObject item = itemsInInventory.Find(x => x.GetComponent<UIItem>().Type == (Item)_num);
        itemsInInventory.Remove(item);
        Destroy(item);
    }
}
