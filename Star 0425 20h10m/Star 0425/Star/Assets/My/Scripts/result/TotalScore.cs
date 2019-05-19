using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text totalScore = GetComponent<Text>();
        if (Goal.ClearFlag == true)
        {
            score = ScoreSet();
            totalScore.text = score.ToString();
        }
        else
        {
            totalScore.text = "NO SCORE";
        }
    }
    public int ScoreSet()
    {
        int scoreSet;
        scoreSet = GameGenerator.Star * 1000000 / (int)GameGenerator.StageTimer;
        return scoreSet;
    }
}
