using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    public enum Stage
    {
        Easy = 1,
        Normal = 3,
        Hard = 5
    };
    public Button[] buttons;

    public const int 
        minStageNumber = 1,
        maxStageNumber = 6;

    string kari = "";
    GameObject sb;

    public static int StageSelectNumber
    {
        get; set;
    }
    // Start is called before the first frame update
    void Start()
    {
        StageSelectNumber = minStageNumber;
        sb = GameObject.Find("StageSelectController");
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
        buttons[(StageSelectNumber - 1) / 2].enabled = true;
        PlanetGenerator.stageNumber = StageSelectNumber - 1;
        ExpText();
        GetComponent<Text>().text = kari;
        if(sb.GetComponent<StageSelectController>().loadFlag)
            sb.GetComponent<StageSelectController>().delaycount++;
    }

    void ExpText()
    {
        switch (StageSelectNumber)
        {
            case (int)Stage.Easy:
                kari = "これはとてもスペシャル";
                break;

            case (int)Stage.Normal:
                kari = "急がば回せ";
                break;

            case (int)Stage.Hard:
                kari = "テクさを魅せろ";
                break;
        }
    }
}
