using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public Text
        resultStar,
        resultTime,
        resultTotal;
    private int
        star,
        timer,
        touchTime;
    private float stageTime;
    private bool 
        starCountEnd,
        timeCountEnd,
        skipNow;
    private TotalScore score;
    private ResultRank resultRank;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TotalScore>();
        resultRank = GetComponent<ResultRank>();
        star = GameGenerator.Star;
        stageTime = GameGenerator.StageTimer;
        timer = 0;
        touchTime = 0;
        starCountEnd = false;
        timeCountEnd = false;
        skipNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            touchTime++;

        if (touchTime >= 2)
            skipNow = true;

        if (!starCountEnd)
            ShowStar();
        else if (!timeCountEnd)
            ShowTime();
        else
        {
            score.ShowTotalScore(resultTotal);
            resultRank.ShowRank(score.ScoreSet());
        }
    }
    private void ShowStar()
    {
        if (timer < star && !skipNow)
        {
            resultStar.text = timer.ToString() + " stars";
            timer += star / (60 * 3);
        }
        else
        {
            resultStar.text = star.ToString() + " stars";
            starCountEnd = true;
            timer = 0;
        }

    }
    private void ShowTime()
    {
        if (timer < (int)stageTime && !skipNow)
        {
            resultTime.text = timer.ToString("f2") + " sec";
            timer ++;
        }
        else
        {
            resultTime.text = stageTime.ToString("f2") + " sec";
            timeCountEnd = true;
        }
    }

}
