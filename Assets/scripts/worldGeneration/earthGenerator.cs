using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class earthGenerator : MonoBehaviour
{

    public GameObject image;
    public GameObject UIparent;
    public GameObject parent;
    public int[][] mapArr = new int[100][];


    public void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            mapArr[i] = new int[100];
        }
        genMap(50, 50);
        genMap(50, 50);
        genMap(50, 50);
        genMap(50, 50);
        genMap(50, 50);
        genMap(50, 50);
        for (int i = 0; i < mapArr.Length; i++)
        {
            for (int j = 0; j < mapArr[i].Length; j++)
            {

                if (mapArr[i][j] == 1)
                {
                    GameObject plane = newPlane();
                    plane.transform.position = new Vector3(i, 0, j);
                    plane.transform.parent = parent.transform;
                }
            }
        }

        GetComponent<drawGrid>().lateStart(UIparent, image);
    }



    int size = 0;
    int help = 0;
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
                if (mapArr[addToMap[0]][addToMap[1]] == 1)
                {
                }
                else
                {
                    size++;
                    mapArr[addToMap[0]][addToMap[1]] = 1;
                    genMap(addToMap[0], addToMap[1]);
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