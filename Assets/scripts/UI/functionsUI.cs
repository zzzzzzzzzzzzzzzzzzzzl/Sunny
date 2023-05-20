using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functionsUI : MonoBehaviour
{
    public GameObject mapUI;
    public GameObject inventoryUI;
    private string open = "none";
    public Dictionary<string, GameObject> UIDict = new Dictionary<string, GameObject>();

    private void Start()
    {
        UIDict.Add("mapUI", mapUI);
        UIDict.Add("inventoryUI", inventoryUI);
    }

    public void toggleUI(string openUI)
    {
        open = openUI;
        foreach (string key in UIDict.Keys)
        {
            if (open == key)
            {
                UIDict[key].SetActive(!UIDict[key].activeSelf);
            }
            else
            {
                UIDict[key].SetActive(false);
            }

        }
    }
}
