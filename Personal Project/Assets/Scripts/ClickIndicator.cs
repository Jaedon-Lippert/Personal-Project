using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIndicator : MonoBehaviour
{
    private GameController game;
    private PlayerMovement playerScript;
    public Material myMat;
    private bool touching;
    public Color defaultCol;
    public Color tColor;
    public Color tDead;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameController").GetComponent<GameController>();
        myMat.color = defaultCol;
        playerScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.GameOver)
        {
            myMat.color = tDead;
        }
    }

    private void OnMouseEnter()
    {
        touching = true;
    }

    private void OnMouseExit()
    {
        touching = false;
    }

    private void OnMouseDown()
    {
        
        if (touching && !game.GameOver) { myMat.color = tColor; }
    }

    private void OnMouseUp()
    {
        if(myMat.color == tColor) { myMat.color = defaultCol; }
    }
}
