using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    public GameObject[] ignore;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ignore.Length; i++)
        {
            //Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), ignore[i].GetComponent<Collider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
