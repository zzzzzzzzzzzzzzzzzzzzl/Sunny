using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInventoryUI : MonoBehaviour
{
    public GameObject player;
    public GameObject inventoryUI;
    public GameObject hotbarUI;
    private int selectedHotbarSlot = 0;
    public void loadInventoryUI()
    {
        Inventory inventory = player.GetComponent<playerObject>().inventory;
        for (int i = 0; i < inventory.inventoryList.Count; i++)
        {
            item newItem = inventory.inventoryList[i];
            if (newItem == null)
            {
            }
            else
            {

                GameObject inventorySlot = inventoryUI.transform.GetChild(i).GetChild(0).gameObject;
                Image slot = inventorySlot.GetComponent<Image>();

                slot.sprite = Resources.Load<Sprite>($"InventorySprites/{newItem.type}");
                slot.color = new Color(1f, 1f, 1f, 1f);
            }
            ;
        }
    }
    private void Update()
    {
        loadInventoryUI();
        loadHotBar();
        LoadHotbarCursor();
    }
    private void loadHotBar()
    {
        Inventory inventory = player.GetComponent<playerObject>().inventory;
        for (int i = 0; i < 5; i++)
        {
            item newItem = inventory.inventoryList[i];
            if (newItem == null)
            {
            }
            else
            {
                GameObject inventorySlot = hotbarUI.transform.GetChild(i).GetChild(0).gameObject;
                Image slot = inventorySlot.GetComponent<Image>();

                slot.sprite = Resources.Load<Sprite>($"InventorySprites/{newItem.type}");
                slot.color = new Color(1f, 1f, 1f, 1f);

            }
        }
    }
    private void LoadHotbarCursor()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i == selectedHotbarSlot)
            {
                Outline outline = hotbarUI.transform.GetChild(selectedHotbarSlot).GetComponent<Outline>();
                outline.effectColor = new Color(1f, 0f, 0f, 1f);
            }
            else
            {
                Outline outline = hotbarUI.transform.GetChild(i).GetComponent<Outline>();
                outline.effectColor = new Color(1f, 0f, 0f, 0f);
            }
        }
    }
    public void movehotbarCursor(int direction)
    {
        selectedHotbarSlot += direction;
        if (selectedHotbarSlot < 0)
        {
            selectedHotbarSlot = 4;
        }
        if (selectedHotbarSlot > 4)
        {
            selectedHotbarSlot = 0;
        }
        LoadHotbarCursor();
    }
}
