using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    public string[] startTags;
    private static string[] tags;

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
}
