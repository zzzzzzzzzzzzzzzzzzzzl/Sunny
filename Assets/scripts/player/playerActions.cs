using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActions : MonoBehaviour
{
    public int[] position;
    public int[] facing;
    public GameObject playerObj;
    public GameObject camera;
    public void movePlayer(int[] arr, float rotation)
    {
        playerObj.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        if (GetComponent<earthGenerator>().tileArr[arr[0] + (int)(playerObj.transform.position.x)][arr[1] + (int)(playerObj.transform.position.z)].walkable == true)
        {
            GetComponent<earthGenerator>().tileArr[(int)playerObj.transform.position.x][(int)playerObj.transform.position.z].player = false;
            playerObj.transform.position += new Vector3(arr[0], 0, arr[1]);
            camera.transform.position += new Vector3(arr[0], 0, arr[1]);
            GetComponent<earthGenerator>().tileArr[(int)playerObj.transform.position.x][(int)playerObj.transform.position.z].player = true;
        }
    }
}


