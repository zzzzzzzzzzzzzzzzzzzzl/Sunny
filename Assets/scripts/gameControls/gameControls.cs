using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControls : MonoBehaviour
{
    public void LateUpdate()
    {

        if (Input.GetKeyUp(KeyCode.W))
        {
            int[] arr = { 0, 1 };
            GetComponent<playerMovement>().movePlayer(arr, 0f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            int[] arr = { 1, 0 };
            GetComponent<playerMovement>().movePlayer(arr, 90f);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            int[] arr = { 0, -1 };
            GetComponent<playerMovement>().movePlayer(arr, 180f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            int[] arr = { -1, 0 };
            GetComponent<playerMovement>().movePlayer(arr, 270f);
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            GetComponent<functionsUI>().toggleUI();
        }
    }
}


