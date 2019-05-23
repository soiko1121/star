using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingReset : MonoBehaviour
{
    public void ResetOnClick()
    {
        for (int loopStage = 1; loopStage <= SelectStage.maxStageNumber; loopStage++)
        {
            for (int loopRank = 1; loopRank <= Ranking.maxRank; loopRank++)
            {
                PlayerPrefs.SetFloat("STAGE" + loopStage + "RANK" + loopRank, 0);
            }
        }
        PlayerPrefs.Save();
    }
}
