using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    public enum Stage
    {
        Easy = 1,
        Normal = 2,
        Hard = 3
    };
    public Button[] buttons;

    public const int 
        minStageNumber = 1,
        maxStageNumber = 3;

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
        sb = GameObject.Find("SelectButton");
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
        buttons[StageSelectNumber-1].enabled = true;
        ExpText();
        GetComponent<Text>().text = kari;
        if(sb.GetComponent<SelectButton>().flag)
            sb.GetComponent<SelectButton>().count++;
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
