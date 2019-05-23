using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIset : MonoBehaviour
{
    [SerializeField]
    GameObject firstUI;
    [SerializeField]
    GameObject secondUI;

    // Start is called before the first frame update
    void Start()
    {
        firstUI.SetActive(true);
        secondUI.SetActive(false);
        SelectStage.StageSelectNumber = SelectStage.minStageNumber;
    }
}