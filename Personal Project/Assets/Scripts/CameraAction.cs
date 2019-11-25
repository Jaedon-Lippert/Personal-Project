using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour
{
    public PlayerMovement playerScript;
    private bool gameOverAction = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.gameOver && !gameOverAction)
        {
            
            GetComponent<AudioSource>().pitch -= 0.01f;

            if(GetComponent<AudioSource>().pitch <= 0.6f)
                gameOverAction = true;
        }
    }
}
