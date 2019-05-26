using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackSet : MonoBehaviour
{
    public Sprite[] backData = new Sprite[2];
    // Update is called once per frame
    void Update()
    {
        if (SelectStage.StageSelectNumber % 2 == 0)
            GetComponent<Image>().sprite = backData[1];
        else
            GetComponent<Image>().sprite = backData[0];
    }
}
