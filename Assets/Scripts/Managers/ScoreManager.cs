using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score; // The player's score.

    Text text; // Reference to the Text component.


    
    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score += 1;
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score;
    }

    public void AddScore(int addScore)
    {
        score += addScore;
    }

}
