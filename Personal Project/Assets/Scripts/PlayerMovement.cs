using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameController game;

    //Launch Dampener
    public float dampProj = 20.0f;
    public float dampPlayer = 50.0f;

    //aiming = true, stays aiming until mouseUp
    private bool aiming = false;

    //mouseOver = true, permits aiming to equal true
    private bool mouseOver;

    //Projectile Prefab
    public GameObject projPrefab;

    //Camera Used
    public Camera cam;

    //Audio Files
    public AudioClip playerDeath;

    private Rigidbody rBody;
    private Transform target;
    private AudioSource audioOutput;

    /*
    //mousePostion
    private float mouseX;
    private float mouseZ;
    */
    //mouseDistance
    private float distX;
    private float distZ;

    //positionOnScreen
    private float camPosX;
    private float camPosZ;
  
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameController").GetComponent<GameController>();

        target = GetComponent<Transform>();
        rBody = GetComponent<Rigidbody>();
        audioOutput = GetComponent<AudioSource>();

        /*
        sHeight = Screen.height;
        sWidth = Screen.width;

        cH = iH / sHeight;
        cW = iW / sWidth;

        Debug.Log(sHeight);
        Debug.Log(sWidth);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Update object position
        camPosX = cam.WorldToScreenPoint(target.position).x;
        camPosZ = cam.WorldToScreenPoint(target.position).y;

        if (!game.GameOver) {
            if (Input.GetKeyDown(KeyCode.Mouse0) && mouseOver)
            {
                aiming = true;
            }
            if (aiming && Input.GetKeyUp(KeyCode.Mouse0))
            {
                //Get Mouse Distance
                distX = (game.MouseX - camPosX) * game.ConvertedWidth;
                distZ = (game.MouseZ - camPosZ) * game.ConvertedHeight;

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
        //game.Projectiles(clone);
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
        /*
        if (hitObject.FindTag("grunt"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        } else if (hitObject.FindTag("bouncer"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
        */
        if (hitObject.FindTag("enemy"))
        {
            Debug.Log("Game Over");
            if (!game.GameOver)
            {
                audioOutput.PlayOneShot(playerDeath);
            }
            game.GameOver = true;
        }
    }
}
