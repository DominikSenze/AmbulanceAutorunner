using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
        
    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSec;
    public bool scoreIncrease;
    
    // Start is called before the first frame update
    void Start()
    {
        //keeping the Highscore when closing and restarting game
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //increasing score
        if (scoreIncrease)
        {
            scoreCount += pointsPerSec * Time.deltaTime;
        }
        
        //increasing high score
        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }
        
        //refreshing content of the text boxes with round numbers
        scoreText.text = "Score:  " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
    }
}
