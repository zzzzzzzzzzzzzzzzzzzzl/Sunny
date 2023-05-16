using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingRod : MonoBehaviour
{
    public item catchFish()
    {
        if (Random.Range(0, 2) == 0)
        {
            return new item("karp");
        }
        else
        {
            return new item("salmon");
        }
    }
}




