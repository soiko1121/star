using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    public void LeftOnClick()
    {
        SelectStage.StageSelect--;
        if (SelectStage.minStageNumber > SelectStage.StageSelect)
        {
            SelectStage.StageSelect = SelectStage.maxStageNumber;
        }
    }
    public void RightOnClick()
    {
        SelectStage.StageSelect++;
        if (SelectStage.maxStageNumber < SelectStage.StageSelect)
        {
            SelectStage.StageSelect = SelectStage.minStageNumber;
        }
    }
    public void StartOnClick()
    {
        SceneManager.LoadScene("LoadScene");
    }
}
