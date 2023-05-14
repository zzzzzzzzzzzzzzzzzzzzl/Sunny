using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class item
{
    public item(string Type)
    {
        Tuple<string> typeData = itemDictionary.itemData[Type];
    }
}
public class itemDictionary : MonoBehaviour
{
    public static Dictionary<string, Tuple<string>> itemData =
     new Dictionary<string, Tuple<string>> {
        { "karp", new Tuple<string>("karp") },
        { "salmon", new Tuple<string>("salmon") }
      };
}




