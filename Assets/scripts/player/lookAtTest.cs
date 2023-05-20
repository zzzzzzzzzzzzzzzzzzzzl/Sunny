using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtTest : MonoBehaviour
{
    public GameObject target; // Reference to the target object (object A)

    private void Update()
    {
        // Check if the target is valid
        if (target != null)
        {



            Vector3 newVec = target.transform.position - transform.position;
            Debug.Log(newVec);
            transform.position += newVec / 100;

            transform.LookAt(target.transform);


        }
    }
}