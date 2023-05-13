using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class earthGenerator : MonoBehaviour
{

    public GameObject image;
    public GameObject parent;
    public GameObject player;
    // public int[][] tileArr = new int[100][];
    public tile[][] tileArr = new tile[100][];


    public void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            tileArr[i] = new tile[100];
            for (int j = 0; j < 100; j++)
            {
                GameObject plane = newPlane();
                plane.transform.position = new Vector3(i, 0, j);
                plane.transform.parent = parent.transform;
                tileArr[i][j] = new tile("water", plane);
            }
        }
        genMap(50, 50);
        genMap(50, 50);
        genMap(50, 50);
        genMap(50, 50);
        genMap(50, 50);
        genMap(50, 50);
        for (int i = 0; i < tileArr.Length; i++)
        {
            for (int j = 0; j < tileArr[i].Length; j++)
            {

                if (tileArr[i][j].type == "dirt")
                {
                    GameObject plane = newPlane();
                    plane.transform.position = new Vector3(i, 0, j);
                    plane.transform.parent = parent.transform;
                }
            }
        }

        tileArr[(int)player.transform.position.x][(int)player.transform.position.z].player = true;
        GetComponent<drawGrid>().drawMap();
    }



    int size = 0;
    public void genMap(int x, int z)
    {

        if (size > 10)
        {
            return;
        }

        if (x > 90 || x < 10 || z > 90 || z < 10)
        {
            return;
        }
        int[][] arr = { new int[] { 1 + x, z }, new int[] { -1 + x, z }, new int[] { x, 1 + z }, new int[] { x, -1 + z } };
        for (int i = 0; i < 10; i++)
        {
            if (0 == Random.Range(0, 0))
            {
                int[] addToMap = arr[Random.Range(0, 4)];
                if (!(tileArr[addToMap[0]][addToMap[1]].type == "dirt"))
                {
                    size++;
                    tileArr[addToMap[0]][addToMap[1]].type = "dirt";

                    GameObject plane = newPlane();
                    plane.transform.position = new Vector3(addToMap[0], 0, addToMap[1]);
                    plane.transform.parent = parent.transform;

                    tileArr[addToMap[0]][addToMap[1]] = new tile("dirt", plane);
                    genMap(addToMap[0], addToMap[1]);
                }
                else
                {
                }


            }
        }

        return;

    }






    // }

    public GameObject newPlane()
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
        return plane;
    }
}