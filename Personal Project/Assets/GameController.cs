using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //SCREEN START
    //Get Screen Size
    private float sHeight;
    private float sWidth;

    //Intended Screen Size
    readonly float iH = 695f;
    readonly float iW = 1540f;

    //Convert
    private float cH;
    private float cW;

    public float ConvertedHeight => cH;
    public float ConvertedWidth => cW;
    //SCREEN END

    //MOUSE CAM START
    //mousePostion
    private float mX;
    private float mZ;

    public float MouseX => mX;
    public float MouseZ => mZ;
    //MOUSE CAM END

    //EnemySpeedModifier
    private float esm;
    public float ESM
    {
        get { return esm; }
        set { esm = value; }
    }

    //GameOver
    private bool gameOver = false;
    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    //game speed
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //CONVERT SCREEN SIZES START
        sHeight = Screen.height;
        sWidth = Screen.width;

        cH = iH / sHeight;
        cW = iW / sWidth;
        //CONVERT SCREEN SIZES END
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            speed /= 1 + 0.5f * Time.deltaTime;
        }
        //Update mose position
        mX = Input.mousePosition.x;
        mZ = Input.mousePosition.y;
    }
}
