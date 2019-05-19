using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    public const int 
        minStageNumber = 1,
        maxStageNumber = 3;

    public static int StageSelectNumber
    {
        get; set;
    }
    // Start is called before the first frame update
    void Start()
    {
        StageSelectNumber = minStageNumber;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = StageSelectNumber.ToString();
    }
}
