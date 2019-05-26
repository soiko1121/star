using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    public int count = 0;
    public bool flag = false;
    public GameObject canvas;

    public void LeftOnClick()
    {
        SelectStage.StageSelectNumber-=2;
        if (SelectStage.minStageNumber > SelectStage.StageSelectNumber)
        {
            SelectStage.StageSelectNumber = SelectStage.maxStageNumber;
        }
    }
    public void RightOnClick()
    {
        SelectStage.StageSelectNumber+= 2;
        if (SelectStage.maxStageNumber < SelectStage.StageSelectNumber)
        {
            SelectStage.StageSelectNumber = SelectStage.minStageNumber;
        }
    }
    public void StartOnClick()
    {
        canvas.SetActive(true);
    }
}
