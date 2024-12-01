using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class Score : MonoBehaviour
{
    public PlayerMove playerMove;
    public int finalscore;
    public TextMeshProUGUI scoreText; // Reference to TextMeshPro UI component

    // Update is called once per frame
    void Update()
    {
        // Update final score
        finalscore = playerMove.score;

        // Display score in TextMeshPro
        scoreText.text = finalscore.ToString()  + "/5";
    }
}
