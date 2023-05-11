using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawGrid : MonoBehaviour
{
    public void lateStart(GameObject parent, GameObject image)
    {
        int[][] arr = GetComponent<earthGenerator>().mapArr;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                GameObject newImage = Instantiate(image);
                if (arr[i][j] == 1)
                {

                    newImage.GetComponent<Image>().color = new Color(Random.Range(0f, .3f), Random.Range(.0f, .6f) + .4f, Random.Range(.0f, .3f) + .1f);
                }


                newImage.transform.SetParent(parent.transform);
                newImage.transform.position = new Vector3(i * 4, j * 4, 0);

                // // Generate a random color for the new image
                // Color randomColor = Random.ColorHSV();

                // // Set the color of the image to the random color
                // newImage.GetComponent<Renderer>().material.color = randomColor;
            }
        }
    }
}
