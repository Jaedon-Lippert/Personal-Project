using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private int score;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
    }

    //Edit Score Method
    public int Score
    {
        get { return score; }
        set { score += value; }
    }
}
