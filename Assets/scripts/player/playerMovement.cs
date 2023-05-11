using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public bool facing;
    public GameObject playerObj;


    public GameObject movePlayer(int[] arr, float rotation)
    {
        playerObj.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        if (GetComponent<earthGenerator>().mapArr[arr[0] + (int)playerObj.transform.position.x][arr[1] + (int)playerObj.transform.position.z] == 1)
        {
            playerObj.transform.position += new Vector3(arr[0], 0, arr[1]);
        }

        facing = (GetComponent<earthGenerator>().mapArr[arr[0] + (int)playerObj.transform.position.x][arr[1] + (int)playerObj.transform.position.z] == 1);
        return playerObj;
    }
}


