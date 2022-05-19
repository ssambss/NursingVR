using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public static int score { get; set; } = 0;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text textResult;

    private void Awake()
    {
        instance = this;       
    }  

    public void ResetScore()
    {
        score = 0;
        DisplayScore();
    }

    public void IncrementScore()
    {
        Debug.Log("1 pojo");
        score++;
        DisplayScore();
    }

    public void IncrementScoreBy2()
    {
        Debug.Log("2 pojoo");
        score += 2;
        DisplayScore();
    }

    public void DecreaseScore()
    {
        score--;
        DisplayScore();
    }

    public void DisplayScore()
    {
        text.text = score.ToString();
        textResult.text = score.ToString();
    }

    


}
