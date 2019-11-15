using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Launch Dampener
    private float dampProj = 20.0f;
    private float dampPlayer = 100.0f;

    //Projectile Prefab
    public GameObject projPrefab;

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
            //Get Mouse Distance
            distX = (mouseX - camPosX);
            distZ = (mouseZ - camPosZ);

            //Launch function
            SelfLaunch(distX/dampPlayer, distZ/dampPlayer, rBody.velocity.y);

            //Shoot Projectile()
            ShootProjectile(-distX/dampProj, -distZ/dampProj, rBody.velocity.y);

            //Shoot end
            aiming = false;
        }

        //PlayerMovement (Transform.Translate)
        /*
        transform.Translate(Vector3.forward * Time.deltaTime * distZ);
        transform.Translate(Vector3.right * Time.deltaTime * distX);
        */
        

    }

    private void ShootProjectile(float dx, float dz, float yVel)
    {
        GameObject clone = Instantiate(projPrefab, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody>().velocity = new Vector3(dx, yVel, dz);
    }

    private void SelfLaunch(float dx, float dz, float yVel)
    {
        //RigidbodyMovement (velocity)
        rBody.velocity = new Vector3(dx, yVel, dz);
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
