using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSelect : MonoBehaviour
{
    public GameObject[] mask = new GameObject[3];
    public void Start()
    {
        MaskOnOff(SelectStage.StageSelectNumber);
    }

    public void Easy()
    {
        if (SelectStage.StageSelectNumber != (int)SelectStage.Stage.Easy)
        {
            SelectStage.StageSelectNumber = (int)SelectStage.Stage.Easy;
            MaskOnOff((int)SelectStage.Stage.Easy);
        }
    }
    public void Normal()
    {
        if (SelectStage.StageSelectNumber != (int)SelectStage.Stage.Normal)
        {
            SelectStage.StageSelectNumber = (int)SelectStage.Stage.Normal;
            MaskOnOff((int)SelectStage.Stage.Normal);
        }
    }
    public void Hard()
    {
        if (SelectStage.StageSelectNumber != (int)SelectStage.Stage.Hard)
        {
            SelectStage.StageSelectNumber = (int)SelectStage.Stage.Hard;
            MaskOnOff((int)SelectStage.Stage.Hard);
        }
    }
    private void MaskOnOff(int maskNum)
    {
        for (int loop = 0; loop < mask.Length; loop++)
        {
            if (loop == maskNum - 1)
                mask[loop].SetActive(false);
            else
                mask[loop].SetActive(true);
        }
    }
}
