using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tile
{


    public string tileType;
    public bool walkable;
    public bool fishable;
    public bool player;
    public GameObject mesh;

    public tile(string tileType, GameObject Mesh)
    {
        this.mesh = Mesh;
        this.tileType = tileType;
        this.mesh.GetComponent<Renderer>().material = (Material)Resources.Load($"tileMaterials/{tileType}");
        if (tileType == "water")
        {
            Animator animator = mesh.AddComponent<Animator>();
            animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load($"tileMaterials/{tileType}Animator");
        }
        this.mesh.SetActive(false);
        TileData Data = tileDictionary.Data[tileType];
        this.tileType = Data.tileType;
        this.walkable = Data.walkable;
        this.fishable = Data.fishable;
    }
}


public class TileData
{
    public string tileType;
    public bool walkable;
    public bool fishable;
    public bool player;
    public GameObject tileGameObject;
    public bool animation;

    public TileData(string tileType, bool walkable, bool fishable, bool player, GameObject tileGameObject, bool animation)
    {
        this.tileType = tileType;
        this.walkable = walkable;
        this.fishable = fishable;
        this.player = player;
        this.tileGameObject = tileGameObject;
        this.animation = animation;
    }
}
public static class tileDictionary
{
    public static Dictionary<string, TileData> Data = new Dictionary<string, TileData>
{
    { "dirt", new TileData("dirt", true, false, false, null, false) },
    { "water", new TileData("water", false, true, false, null, true) }
};
}




