using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //aiming = true, stays aiming until mouseUp
    private bool aiming = false;

    //mouseOver = true, permits aiming to equal true
    private bool mouseOver;

    //Camera Used
    public Camera cam;

    public Rigidbody rBody;

    //mousePostion
    private float mouseX;
    private float mouseZ;

    //mouseDistance
    private float distX;
    private float distZ;

    //positionOnScreen
    private float camPosX;
    private float camPosZ;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Update object position
        camPosX = cam.WorldToScreenPoint(target.position).x;
        camPosZ = cam.WorldToScreenPoint(target.position).y;

        //Update mose position
        mouseX = Input.mousePosition.x;
        mouseZ = Input.mousePosition.y;

        if (Input.GetKeyDown(KeyCode.Mouse0) && mouseOver)
        {
            aiming = true;
        }
        if (aiming && Input.GetKeyUp(KeyCode.Mouse0))
        {
            //Temp Var
            float yVel = rBody.velocity.y;

            //Get Mouse Distance
            distX = (mouseX - camPosX)/20;
            distZ = (mouseZ - camPosZ)/20;

            //Shoot function
            aiming = false;

            //RigidbodyMovement (velocity)
            rBody.velocity = new Vector3(distX, yVel, distZ);
        }

        //PlayerMovement (Transform.Translate)
        /*
        transform.Translate(Vector3.forward * Time.deltaTime * distZ);
        transform.Translate(Vector3.right * Time.deltaTime * distX);
        */
        

    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }
}
