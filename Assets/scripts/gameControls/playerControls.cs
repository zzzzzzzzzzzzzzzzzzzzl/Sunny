using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject rod;
    public bool facing;



    public void LateUpdate()
    {

        if (Input.GetKeyUp(KeyCode.W))
        {
            int[] arr = { 0, 1 };
            movePlayer(arr, 0f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            int[] arr = { 1, 0 };
            movePlayer(arr, 90f);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            int[] arr = { 0, -1 };
            movePlayer(arr, 180f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            int[] arr = { -1, 0 };
            movePlayer(arr, 270f);
        }

        if (Input.GetKeyUp(KeyCode.F))//toggle rod
        {
            if (!(facing))
            {
                rod.SetActive(true);
            }

        }
    }
    int[] direction()
    {
        // int[][] arr=GetComponent<earthGenerator>().mapArr
        return new int[0];
    }

    void quitActions()
    {//put all player actions in here
        rod.SetActive(false);//
    }
    void movePlayer(int[] arr, float rotation)
    {
        quitActions();
        playerObj.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        if (GetComponent<earthGenerator>().mapArr[arr[0] + (int)playerObj.transform.position.x][arr[1] + (int)playerObj.transform.position.z] == 1)
        {
            playerObj.transform.position += new Vector3(arr[0], 0, arr[1]);
        }

        facing = (GetComponent<earthGenerator>().mapArr[arr[0] + (int)playerObj.transform.position.x][arr[1] + (int)playerObj.transform.position.z] == 1);
        return;
    }
}


