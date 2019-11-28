using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour
{
    private GameController game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.GameOver && GetComponent<AudioSource>().pitch > 0.6f)
        {

            GetComponent<AudioSource>().pitch /= 1.0f + 0.3f * Time.deltaTime;
        }
    }
}
