using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functionsUI : MonoBehaviour
{
    public GameObject UI;

    public void toggleUI()
    {
        GetComponent<drawGrid>().drawMap();
        UI.SetActive(!UI.activeSelf);
    }
}
