using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private Pulse parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<Pulse>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(parent.CapRot);
        Debug.Log(parent.CapRot);
    }
}
