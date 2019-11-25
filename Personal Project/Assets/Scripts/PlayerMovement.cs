using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //SCREEN START
    //Get Screen Size
    private float sHeight;
    private float sWidth;

    //Intended Screen Size
    private float iH = 695f;
    private float iW = 1540f;

    //Convert
    private float cH;
    private float cW;
    //SCREEN END

    //Launch Dampener
    private float dampProj = 20.0f;
    private float dampPlayer = 50.0f;

    //aiming = true, stays aiming until mouseUp
    private bool aiming = false;

    //mouseOver = true, permits aiming to equal true
    private bool mouseOver;

    //Projectile Prefab
    public GameObject projPrefab;

    //Camera Used
    public Camera cam;

    //Game Status
    public bool gameOver = false;

    private Rigidbody rBody;
    private Transform target;

    //mousePostion
    private float mouseX;
    private float mouseZ;

    //mouseDistance
    private float distX;
    private float distZ;

    //positionOnScreen
    private float camPosX;
    private float camPosZ;

  
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
        rBody = GetComponent<Rigidbody>();


        sHeight = Screen.height;
        sWidth = Screen.width;

        cH = iH / sHeight;
        cW = iW / sWidth;

        Debug.Log(sHeight);
        Debug.Log(sWidth);
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
        if (!gameOver) {
            if (Input.GetKeyDown(KeyCode.Mouse0) && mouseOver)
            {
                aiming = true;
            }
            if (aiming && Input.GetKeyUp(KeyCode.Mouse0))
            {
                //Get Mouse Distance
                distX = (mouseX - camPosX) * cW;
                distZ = (mouseZ - camPosZ) * cH;

                //Launch function
                SelfLaunch(distX / dampPlayer, distZ / dampPlayer, rBody.velocity.y);

                //Shoot Projectile()
                ShootProjectile(-distX / dampProj, -distZ / dampProj, rBody.velocity.y);

                //Shoot end
                aiming = false;
            }
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

    private void OnCollisionEnter(Collision collision)
    {
        Tags hitObject = collision.gameObject.GetComponent<Tags>();

        if (hitObject.FindTag("grunt"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        } else if (hitObject.FindTag("bouncer"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
