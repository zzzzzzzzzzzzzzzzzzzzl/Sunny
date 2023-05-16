using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class item
{
    public string type;
    public item(string Type)
    {
        type = Type;
        Tuple<string> typeData = itemDictionary.itemData[Type];
    }
}
public class itemDictionary : MonoBehaviour
{
    public static Dictionary<string, Tuple<string>> itemData =
     new Dictionary<string, Tuple<string>> {
        { "karp", new Tuple<string>("karp") },
        { "salmon", new Tuple<string>("salmon") },
        { "good rod", new Tuple<string>("good rod") },
        { "badmonkey", new Tuple<string>("badmonkey") }
      };
}




