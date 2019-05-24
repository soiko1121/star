using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    private float 
        stock, 
        setStock;
    public const int maxRank = 3;
    private bool onece;
    private TotalScore score;
    // Start is called before the first frame update
    void Start()
    {
        onece = false;
        score = GetComponent<TotalScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Goal.ClearFlag && !onece)
        {
            stock = score.ScoreSet();
            for (int i = 1; i <= maxRank; i++)
            {
                if (PlayerPrefs.GetFloat("STAGE" + SelectStage.StageSelectNumber + "RANK" + i, 0) < stock)
                {
                    setStock = PlayerPrefs.GetFloat("STAGE" + SelectStage.StageSelectNumber + "RANK" + i, 0);
                    PlayerPrefs.SetFloat("STAGE" + SelectStage.StageSelectNumber + "RANK" + i, stock);
                    stock = setStock;
                }
            }
            PlayerPrefs.Save();
            onece = true;
        }
    }
}
