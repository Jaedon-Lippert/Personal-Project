using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    private GameObject player;
    private GameController game;
    //private Transform pulse;
    private float pulseTimer;
    private float pulseTimerGoal;
    private float pulseRadius;
    private Vector3 capsuleRotation;
    public Vector3 CapRot => capsuleRotation;
    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameController").GetComponent<GameController>();
        rBody = GetComponent<Rigidbody>();
        //pulse = GetComponentInChildren<Transform>();
        player = GameObject.Find("Player");
        pulseTimerGoal = 5;
        pulseRadius = 5;
        SpawnShoot();
        //Physics.IgnoreCollision(GetComponent<SphereCollider>(), pulse.GetComponent<CapsuleCollider>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        capsuleRotation = new Vector3(0.0f, 0.0f, 1440.0f) * (pulseTimer/pulseTimerGoal) * Time.deltaTime;
        //pulse./*transform.*/Rotate(capsuleRotation * (pulseTimer/pulseTimerGoal) * Time.deltaTime);
        //transform.position = pulse./*transform.*/position;
        if(pulseTimer < pulseTimerGoal) pulseTimer += Time.deltaTime;
        else
        {
            ExecuteBlast();
            Destroy(gameObject);
        }
        
    }
    void ExecuteBlast()
    {

        //Get the players position relative to the blast source
        Vector3 objectDistance; 
        float mag;

        objectDistance = new Vector3(player.transform.position.x - transform.position.x, 0.0f, player.transform.position.z - transform.position.z);
        mag = objectDistance.magnitude;

        if (mag <= pulseRadius)
        {
            player.GetComponent<Rigidbody>().AddForce(objectDistance * (pulseRadius - mag) * 3, ForceMode.Impulse);
            Debug.Log("Hit Player");        
        }

        for (int i = 0; i < game.ProjectilesInScene.Length; i++)
        {
            objectDistance = new Vector3(game.ProjectilesInScene[i].transform.position.x - transform.position.x, 0.0f, game.ProjectilesInScene[i].transform.position.z - transform.position.z);
            mag = objectDistance.magnitude;
            if (mag <= pulseRadius)
            {
                game.ProjectilesInScene[i].GetComponent<Rigidbody>().AddForce(objectDistance * (pulseRadius - mag) * 3, ForceMode.Impulse);
                Debug.Log("Hit Projectile");
            }
        }
        //Debug.Log("Player Distance Magnitude was " + playerMag);

    }
    void SpawnShoot()
    {
        float burstMax = Random.Range(5.0f, 10.0f);

        int xCharge = Random.Range(-1, 2);
        int zCharge = Random.Range(-1, 2);

        float xSpeed = Random.Range(0.0f, 1.0f);
        float zSpeed = 1 - xSpeed;

        xSpeed *= xCharge;
        zSpeed *= zCharge;

        rBody.AddForce(xSpeed * burstMax, 0.0f, zSpeed * burstMax, ForceMode.Impulse);
    }
}
