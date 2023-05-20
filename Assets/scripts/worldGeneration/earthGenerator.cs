using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class earthGenerator : MonoBehaviour
{

    public GameObject parent;
    public GameObject player;
    public GameObject scriptManager;
    public GameObject mesh1;
    public GameObject mesh2;
    public GameObject mesh3;



    public tile[][] tileArr = new tile[100][];


    public void Start()
    {
        int[][] arr = genArr(100);
        for (int i = 0; i < 100; i++)
        {
            tileArr[i] = new tile[100];

            for (int j = 0; j < 100; j++)
            {
                if (arr[i][j] == 1)
                {

                    tileArr[i][j] = new tile("dirt", newPlane(i, j));
                }
                else
                {
                    tileArr[i][j] = new tile("water", newPlane(i, j));
                }
            }
        }

        GameObject water = combineMeshs("water");
        GameObject dirt = combineMeshs("dirt");

    }
    private List<MeshFilter> sortTile(string tileType)
    {
        List<MeshFilter> list = new List<MeshFilter>();
        foreach (tile[] i in tileArr)
        {
            foreach (tile j in i)
            {
                if (j.tileType == tileType)
                {
                    list.Add(j.mesh.GetComponent<MeshFilter>());
                }
            }
        }
        return list;
    }
    private int[][] genArr(int size)
    {
        int[][] arr = new int[size][];
        for (int i = 0; i < size; i++)
        {
            arr[i] = new int[size];
        }
        arr = genMap(50, 50, arr, 0, 100);
        arr[50][50] = 1;
        arr = edgeUp(arr);
        return arr;

    }
    private int[][] edgeUp(int[][] arr)
    {
        List<int[]> arrList = new List<int[]>();
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                int[][] direction = { new int[] { 1 + i, j }, new int[] { -1 + i, j }, new int[] { i, 1 + j }, new int[] { i, -1 + j } };

                if (arr[i][j] == 1)
                {
                    foreach (int[] k in direction)
                    {
                        arrList.Add(k);
                    }
                }
            }
        }
        foreach (int[] i in arrList)
        {
            arr[i[0]][i[1]] = 1;
        }
        return arr;
    }


    private int recursion = 0;
    private int[][] genMap(int x, int z, int[][] arr, int recursion, int size)
    {

        if (recursion > size)
        {
            return arr;
        }
        int[][] direction = { new int[] { 1 + x, z }, new int[] { -1 + x, z }, new int[] { x, 1 + z }, new int[] { x, -1 + z } };
        for (int j = 0; j < 10; j++)
        {
            int[] addToMap = direction[Random.Range(0, 4)];
            recursion++;
            arr[addToMap[0]][addToMap[1]] = 1;
            return genMap(addToMap[0], addToMap[1], arr, recursion, size);

        }

        return arr;
    }
    public GameObject newPlane(int x, int z)
    {
        GameObject plane = new GameObject("Plane");

        MeshFilter meshFilter = plane.AddComponent<MeshFilter>();

        MeshRenderer meshRenderer = plane.AddComponent<MeshRenderer>();
        Mesh newMesh = new Mesh();
        meshFilter.mesh = newMesh;
        Material newMaterial = new Material(Shader.Find("Standard"));
        meshRenderer.material = newMaterial;

        Mesh mesh = new Mesh();


        mesh.vertices = new Vector3[] {
            new Vector3(-0.5f, 0, -0.5f),
            new Vector3(-0.5f, 0, 0.5f),
            new Vector3(0.5f, 0, 0.5f),
            new Vector3(0.5f, 0, -0.5f)
        };
        mesh.triangles = new int[] { 0, 1, 2, 2, 3, 0 };
        mesh.uv = new Vector2[] {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(1, 0)
        };
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        meshFilter.mesh = mesh;
        plane.transform.position = new Vector3(x, 0, z);
        plane.transform.SetParent(parent.transform);

        return plane;
    }

    private GameObject combineMeshs(string tileType)
    {

        List<MeshFilter> sourceMeshFilters = new List<MeshFilter>();
        foreach (tile[] i in tileArr)
        {
            foreach (tile j in i)
            {
                if (j.tileType == tileType)
                {

                    sourceMeshFilters.Add(j.mesh.GetComponent<MeshFilter>());
                }
            }
        }

        CombineInstance[] combine = new CombineInstance[sourceMeshFilters.Count];
        Debug.Log(sourceMeshFilters.Count);
        for (var i = 0; i < sourceMeshFilters.Count; i++)
        {
            combine[i].mesh = sourceMeshFilters[i].sharedMesh;
            combine[i].transform = sourceMeshFilters[i].transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combine);


        GameObject newGameobject = new GameObject();
        MeshFilter targetMeshFilter = newGameobject.AddComponent<MeshFilter>();
        Debug.Log(targetMeshFilter);
        targetMeshFilter.mesh = mesh;
        newGameobject.name = $"{tileType}CombinedMesh";
        newGameobject.AddComponent<MeshRenderer>();
        newGameobject.GetComponent<MeshRenderer>().material = (Material)Resources.Load($"tileMaterials/{tileType}");
        if (tileDictionary.Data[tileType].animation)
        {
            Animator animator = newGameobject.AddComponent<Animator>();
            animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load($"tileMaterials/{tileType}Animator");
        }
        return newGameobject;
    }
}