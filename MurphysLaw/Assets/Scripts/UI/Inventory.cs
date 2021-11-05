using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public GameObject[] ItemObjects;

    private List<GameObject> itemsInInventory;
    public void AddItem(int _num)
    {
        itemsInInventory.Add(Instantiate(ItemObjects[_num], this.transform));
        itemsInInventory[itemsInInventory.Count - 1].transform.parent = this.gameObject.transform;
    }
    public void DelItem(int _num)
    {
        GameObject item = itemsInInventory.Find(x => x.GetComponent<UIItem>().Type == (Item)_num);
        itemsInInventory.Remove(item);
        Destroy(item);
    }
}
