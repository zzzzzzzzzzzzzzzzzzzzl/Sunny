using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerObject : MonoBehaviour
{
    public Inventory inventory = new Inventory(30);
    public void Start()
    {
        Debug.Log("player has itmes good job");
        addItem(new item("good rod"));
    }
    public void addItem(item item)
    {
        for (int i = 0; i < inventory.inventoryList.Count; i++)
        {
            if (inventory.inventoryList[i] == null)
            {
                inventory.inventoryList[i] = item;
                break;
            }
        }
    }
}


