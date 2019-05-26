using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSelect : MonoBehaviour
{
    public GameObject[] mask = new GameObject[3];
    private int setMask;

    public void Easy()
    {
        if (SelectStage.StageSelectNumber != (int)SelectStage.Stage.Easy)
        {
            SelectStage.StageSelectNumber = (int)SelectStage.Stage.Easy;
        }
    }
    public void Normal()
    {
        if (SelectStage.StageSelectNumber != (int)SelectStage.Stage.Normal)
        {
            SelectStage.StageSelectNumber = (int)SelectStage.Stage.Normal;
        }
    }
    public void Hard()
    {
        if (SelectStage.StageSelectNumber != (int)SelectStage.Stage.Hard)
        {
            SelectStage.StageSelectNumber = (int)SelectStage.Stage.Hard;
        }
    }
    void Update()
    {
        if (SelectStage.StageSelectNumber % 2 == 0)
            setMask = SelectStage.StageSelectNumber - 1;
        else
            setMask = SelectStage.StageSelectNumber;

        switch (setMask)
        {
            case (int)SelectStage.Stage.Easy:
                mask[0].SetActive(false);
                mask[1].SetActive(true);
                mask[2].SetActive(true);
                break;
            case (int)SelectStage.Stage.Normal:
                mask[0].SetActive(true);
                mask[1].SetActive(false);
                mask[2].SetActive(true);
                break;
            case (int)SelectStage.Stage.Hard:
                mask[0].SetActive(true);
                mask[1].SetActive(true);
                mask[2].SetActive(false);
                break;
            default:
                break;
        }
    }
}
