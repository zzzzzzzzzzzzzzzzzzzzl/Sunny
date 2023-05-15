using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInventoryUI : MonoBehaviour
{
    public GameObject player;
    public GameObject inventoryUI;
    public void loadInventoryUI()
    {
        Inventory inventory = player.GetComponent<playerObject>().inventory;
        for (int i = 0; i < inventoryUI.transform.childCount; i++)
        {
            GameObject inventorySlot = inventoryUI.transform.GetChild(i).GetChild(0).gameObject;
            Image slot = inventorySlot.GetComponent<Image>();
            slot.sprite = Resources.Load<Sprite>($"InventorySprites/karp");
            slot.color = new Color(1f, 1f, 1f, 1f);
            ;
        }

    }
}
