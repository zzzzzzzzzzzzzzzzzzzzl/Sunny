// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class drawGrid : MonoBehaviour
// {
//     public GameObject parent;
//     public GameObject image;
//     public void drawMap()
//     {
//         int[][] arr = GetComponent<earthGenerator>().mapArr;

//         for (int i = 0; i < arr.Length; i++)
//         {
//             for (int j = 0; j < arr[i].Length; j++)
//             {
//                 GameObject newImage = Instantiate(image);
//                 if (arr[i][j] == 1)
//                 {

//                     newImage.GetComponent<Image>().color = new Color(Random.Range(0f, .3f), Random.Range(.0f, .6f) + .4f, Random.Range(.0f, .3f) + .1f);
//                 }


//                 newImage.transform.SetParent(parent.transform);
//                 newImage.transform.position = new Vector3(i * 4, j * 4, 0);
//             }
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawGrid : MonoBehaviour
{
    public GameObject parent;
    public int pixelSize = 20;
    public Texture2D mapTexture;

    public void drawMap()
    {
        // create a new texture for the map with the same dimensions as the map array
        tile[][] arr = GetComponent<earthGenerator>().tileArr;
        mapTexture = new Texture2D(arr.Length, arr[0].Length);

        // set each pixel in the texture based on the value in the map array
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j].type == "dirt")
                {
                    mapTexture.SetPixel(i, j, new Color(Random.Range(0f, .3f), Random.Range(.0f, .2f) + .6f, Random.Range(.0f, .2f) + .1f));
                }
                if (arr[i][j].type == "water")
                {
                    mapTexture.SetPixel(i, j, new Color(Random.Range(0f, .1f), Random.Range(.0f, .1f) + .3f, Random.Range(.0f, .1f) + .5f));
                }
                if (arr[i][j].player == true)
                {
                    mapTexture.SetPixel(i, j, new Color(Random.Range(0f, .2f) + .7f, Random.Range(.0f, .1f) + .5f, Random.Range(.0f, .1f) + .5f));

                }
            }
        }

        // apply the changes to the texture and set it as the texture for the parent object's renderer
        mapTexture.Apply();
        Sprite sprite = Sprite.Create(mapTexture, new Rect(0, 0, mapTexture.width, mapTexture.height), new Vector2(0.5f, 0.5f));
        sprite.texture.filterMode = FilterMode.Point;
        parent.GetComponent<Image>().sprite = sprite;
        parent.transform.localScale = new Vector3(pixelSize, pixelSize, 1);
    }
}
