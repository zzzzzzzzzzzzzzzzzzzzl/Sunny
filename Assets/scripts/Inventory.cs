using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<item> inventoryList = new List<item>();
    public Inventory(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            inventoryList.Add(null);
        }
    }
    public void AddItem(item newItem, int slot)
    {
        inventoryList[slot] = newItem;
    }
}
