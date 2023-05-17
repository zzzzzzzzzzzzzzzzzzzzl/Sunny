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
        int[] moveArr = new int[] { 0, 0 };
        if (Input.GetKey(KeyCode.W))
        {

            moveArr[0] += 1;
            moveArr[1] += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {

            moveArr[0] += -1;
            moveArr[1] += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {

            moveArr[0] += -1;
            moveArr[1] += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {

            moveArr[0] += 1;
            moveArr[1] += -1;
        }
        player.GetComponent<playerObject>().movePlayer(moveArr, 0f);
    }
    private void UIControls()
    {
        GetComponent<drawGrid>().drawMap();
        if (Input.GetKeyUp(KeyCode.M))
        {
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
