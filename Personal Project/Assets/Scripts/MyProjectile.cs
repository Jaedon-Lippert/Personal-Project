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
        //Get Tag Component
        Tags tg = other.GetComponent<Tags>();

        //Collisions
        if (tg.FindTag("boundary"))
        {
            //collision with wall
            Debug.Log("Hit a Wall");
            Destroy(gameObject);
        }
        else if (tg.FindTag("grunt"))
        {
            //collision with grunt
            Debug.Log("Hit a Grunt");
            Destroy(gameObject);
            Destroy(other);
        }
    }
}
