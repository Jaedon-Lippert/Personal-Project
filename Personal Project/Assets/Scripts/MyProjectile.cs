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

    //FIX detects only grunt
    private void OnTriggerEnter(Collider other)
    {
        //Get Tag Component
        Tags hitObject = other.GetComponent<Tags>();

        //Collisions
        if (hitObject.FindTag("boundary"))
        {
            //collision with wall
            Debug.Log("Hit a Wall");
            Destroy(gameObject);
        }
        else if (hitObject.FindTag("grunt"))
        {
            //collision with grunt
            Debug.Log("Hit a Grunt");
            Destroy(gameObject);
            Destroy(other.gameObject); //<---- Deletes Boundary Collider (Should not be doing this)
        }
    }
}
