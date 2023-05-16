using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class earthGenerator : MonoBehaviour
{

    public GameObject parent;
    public GameObject player;

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

        return arr;

    }
    private int[][] edgeUp(int[][] arr)
    {
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                if (arr[i][j] == 1) { }
            }
        }
        return arr;
    }
    private bool checkNeighbours(int[][] arr)
    {

        return false;
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
}