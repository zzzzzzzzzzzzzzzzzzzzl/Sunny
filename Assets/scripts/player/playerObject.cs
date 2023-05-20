using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerObject : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject playerModel;
    public GameObject script;
    public GameObject camera;
    private Animator animator;
    public Inventory inventory = new Inventory(30);
    public tile facing;
    tile[][] tileArr;
    public void Start()
    {
        animator = playerModel.GetComponent<Animator>();
        tileArr = script.GetComponent<earthGenerator>().tileArr;
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

    public void movePlayer(int[] arr, float rotation)
    {

        if (tileArr[(int)((arr[0] * speed) + transform.position.x + .5f)][+(int)((arr[1] * speed) + transform.position.z + .5f)].walkable == true)
        {
            tileArr[(int)transform.position.x][(int)transform.position.z].player = false;
            transform.position += new Vector3(arr[0] * speed, 0, arr[1] * speed);
            camera.transform.position += new Vector3(arr[0] * speed, 0, arr[1] * speed);
            tileArr[(int)transform.position.x][(int)transform.position.z].player = true;
            facing = tileArr[(int)((arr[0] * speed) + transform.position.x + 1f)][+(int)((arr[1] * speed) + transform.position.z + 1f)];
        }
    }
    public void setAnimationState(string state)
    {
        animator.SetTrigger(state);
    }







}


