using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControls : MonoBehaviour
{

    public GameObject player;
    private void Update()
    {
        playerMovement();
        UIControls();
        interact();
        hotbarCursor();


    }
    private void playerMovement()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            int[] arr = { 1, 1 };
            GetComponent<playerActions>().movePlayer(arr, 0f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            int[] arr = { 1, -1 };
            GetComponent<playerActions>().movePlayer(arr, 90f);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            int[] arr = { -1, -1 };
            GetComponent<playerActions>().movePlayer(arr, 180f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            int[] arr = { -1, 1 };
            GetComponent<playerActions>().movePlayer(arr, 270f);
        }
    }
    private void UIControls()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            GetComponent<drawGrid>().drawMap();
            GetComponent<functionsUI>().toggleUI("mapUI");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            GetComponent<playerInventoryUI>().loadInventoryUI();
            GetComponent<functionsUI>().toggleUI("inventoryUI");
        }
    }
    private void interact()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("here");
            playerObject test = player.GetComponent<playerObject>();
            fishingRod a = new fishingRod();
            test.addItem(a.catchFish());
        }
    }
    private void hotbarCursor()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput < 0)
        {
            GetComponent<playerInventoryUI>().movehotbarCursor(1);
        }
        if (scrollInput > 0)
        {
            GetComponent<playerInventoryUI>().movehotbarCursor(-1);
        }
    }
}
