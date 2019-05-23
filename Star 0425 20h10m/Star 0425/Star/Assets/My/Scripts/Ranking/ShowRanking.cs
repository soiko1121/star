using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRanking : MonoBehaviour
{
    public Text[] rankingText = new Text[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rankingText[0].text = PlayerPrefs.GetFloat("STAGE" + SelectStage.StageSelectNumber + "RANK" + 1, 0).ToString();
        rankingText[1].text = PlayerPrefs.GetFloat("STAGE" + SelectStage.StageSelectNumber + "RANK" + 2, 0).ToString();
        rankingText[2].text = PlayerPrefs.GetFloat("STAGE" + SelectStage.StageSelectNumber + "RANK" + 3, 0).ToString();
    }
}
