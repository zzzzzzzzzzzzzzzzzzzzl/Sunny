using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tile
{


    public string type;
    public bool walkable;
    public bool fishable;
    public bool player;
    public GameObject mesh;

    public tile(string Type, GameObject Mesh)
    {
        mesh = Mesh;
        type = Type;
        mesh.GetComponent<Renderer>().material = (Material)Resources.Load($"tileMaterials/{type}");
        Tuple<string, bool, bool, bool, GameObject> typeData = tileDictionary.tileData[Type];
        type = typeData.Item1;
        walkable = typeData.Item2;
        fishable = typeData.Item3;
    }
}
public class tileDictionary : MonoBehaviour
{
    //we should put our game object templates here

    //Tuple<string,bool,bool,bool>
    //Tuple<type,walkable,fishable,player>


    public static Dictionary<string, Tuple<string, bool, bool, bool, GameObject>> tileData =
     new Dictionary<string, Tuple<string, bool, bool, bool, GameObject>> {
        { "dirt", new Tuple<string, bool, bool,bool,GameObject>("dirt", true, false,false,null) },
        { "water", new Tuple<string, bool, bool,bool,GameObject>("water", false, true,false,null) }
      };
}




