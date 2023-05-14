using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject UI;
    public string open = "none";

    public void toggleUI()
    {
        // GetComponent<drawGrid>().drawMap();
        UI.SetActive(!UI.activeSelf);
    }
}
