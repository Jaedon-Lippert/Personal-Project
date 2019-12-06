using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    public string[] startTags;
    private string[] tags;

    private void Start()
    {
        tags = startTags;
    }
    
    public bool FindTag(string search)
    {
        bool results = false;
        for (int i = 0; i < tags.Length; i++)
        {
            if(search == tags[i])
            {
                results = true;
                break;
            }
        }
        return results;
    }

    public static GameObject[] ObjectsByTag(string search)
    {
        //Get all objects in scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        GameObject[] storedObjects = new GameObject[allObjects.Length];
        //Filter
        for (int i = 0; i < allObjects.Length; i++)
        {

        }
    }
}
