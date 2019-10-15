using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIndicator : MonoBehaviour
{
    public Material myMat;
    private Color defaultCol;
    private bool touching;
    public Color tColor;
    // Start is called before the first frame update
    void Start()
    {
        defaultCol = myMat.color;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (touching) { myMat.color = tColor; }
    }

    private void OnMouseUp()
    {
        if(myMat.color == tColor) { myMat.color = defaultCol; }
    }
}
