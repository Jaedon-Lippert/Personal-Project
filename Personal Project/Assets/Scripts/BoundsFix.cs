using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsFix : MonoBehaviour
{
    private float minX = -7.5f;
    private float minZ = -5f;
    private float maxX = 7.5f;
    private float maxZ = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float[] pos = { transform.position.x, transform.position.y, transform.position.z };
        if (pos[0] < minX) transform.position = new Vector3(minX + 1, pos[1], pos[2]);
        if (pos[2] < minZ) transform.position = new Vector3(pos[0], pos[1], minZ + 1);
        if (pos[0] > maxX) transform.position = new Vector3(maxX - 1, pos[1], pos[2]);
        if (pos[2] > maxZ) transform.position = new Vector3(pos[0], pos[1], maxZ - 1);
    }
}
