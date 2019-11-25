using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProjectile : MonoBehaviour
{
    private GameObject UIcanvas;
    private float lifeSpan = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("selfDestroy", lifeSpan);
        UIcanvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {

    }
    
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
            Destroy(other.gameObject);

            //On destroy
            UIcanvas.GetComponent<UI>().Score = 1;
        }
        else if (hitObject.FindTag("bouncer"))
        {
            //collision with bouncer
            Debug.Log("Hit a Bouncer");
            Destroy(gameObject);
            Destroy(other.gameObject);

            //On destroy
            UIcanvas.GetComponent<UI>().Score = 1;
        }
    }

    private void selfDestroy()
    {
        Destroy(gameObject);
    }
}
