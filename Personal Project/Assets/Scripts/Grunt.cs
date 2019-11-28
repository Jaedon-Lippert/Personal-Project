using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour
{
    private GameObject player;
    private GameController game;

    //Player Position
    private float distX;
    private float distY;

    //Spawn Manager Script
    //private SpawnManager spawnScript;

    //Movement
    public float speed = 2.0f;

    //Priority
    private char prio = '!';

    //Position Threshold
    readonly float posThresh = 0.5f;

    
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameController").GetComponent<GameController>();
        player = GameObject.Find("Player");
        //spawnScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get distance from player
        distX = transform.position.x - player.transform.position.x;
        distY = transform.position.z - player.transform.position.z;

        if (Mathf.Abs(distX) < posThresh && prio == 'x') prio = '!';
        if (Mathf.Abs(distY) < posThresh && prio == 'y') prio = '!';

        switch (prio)
        {
            case 'x':
                transform.Translate(Vector3.left * Time.deltaTime * Charge(distX) * speed * game.speed, Space.World);
                //Debug.Log(Mathf.Abs(distX) + " < " + Mathf.Abs(distY));
                break;
            case 'y':
                transform.Translate(Vector3.back * Time.deltaTime * Charge(distY) * speed * game.speed, Space.World);
                //Debug.Log(Mathf.Abs(distX) + " > " + Mathf.Abs(distY));
                break;
            case '!':
                //Set Priority
                if (Mathf.Abs(distX) > Mathf.Abs(distY) && prio == '!') prio = 'x';
                else if (Mathf.Abs(distX) < Mathf.Abs(distY) && prio == '!') prio = 'y';
                break;
        }


    }

    private float Charge(float x)
    {
        float charge = 0;
        if (x < 0)
        {
            charge = -1;
        }
        else if (x > 0)
        {
            charge = 1;
        }
        return charge;
    }
}
