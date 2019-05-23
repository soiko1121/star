using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public Text resultScore, resultTime;
    private int score, timer, touchTime;
    private float stageTime;
    private bool starCountEnd;
    // Start is called before the first frame update
    void Start()
    {
        score = GameGenerator.Star;
        stageTime = GameGenerator.StageTimer;
        timer = 0;
        touchTime = 0;
        starCountEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            touchTime++;
        else
            touchTime = 0;

        if (touchTime > 60)
        {
            if (!starCountEnd)
                timer = score;
            else
                timer = (int)stageTime;
        }

        if (timer < score && !starCountEnd)
        {
            resultScore.text = timer.ToString() + " stars";
            timer++;
        }
        else
        {
            resultScore.text = score.ToString() + " stars";
            starCountEnd = true;
        }

        if (starCountEnd)
        {
            if (timer < (int)stageTime)
            {
                resultTime.text = timer.ToString("f2") + " sec";
                timer++;
            }
            else
            {
                resultTime.text = stageTime.ToString("f2") + " sec";
            }
        }
    }
}
