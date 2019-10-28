using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProjectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if collider has the boundary tag boundary
        Tags tg = other.GetComponent<Tags>();
        tg.FindTag("boundary");

        //Destroy Myself
        Debug.Log("Hit a Wall");
        Destroy(gameObject);
    }
}
