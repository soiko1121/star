using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public static bool IsClear
    {
        get; set;
    }
    public void ShowTotalScore(Text ScoreText)
    {
        if (IsClear == true)
        {
            ScoreText.text = ScoreSet().ToString();
        }
        else
        {
            ScoreText.text = "NO SCORE";
        }
    }
    public int ScoreSet()
    { 
        return (int)(GameGenerator.Star * 1000000 / GameGenerator.StageTimer);
    }
}
