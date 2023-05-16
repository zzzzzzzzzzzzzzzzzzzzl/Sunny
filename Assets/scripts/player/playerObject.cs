using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerObject : MonoBehaviour
{
    public Inventory inventory = new Inventory(30);
    public void Start()
    {
        addItem(new item("good rod"));
        addItem(new item("karp"));
        addItem(new item("karp"));
        addItem(new item("karp"));
        addItem(new item("karp"));
        addItem(new item("karp"));
        addItem(new item("salmon"));
        addItem(new item("salmon"));
        addItem(new item("salmon"));

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


