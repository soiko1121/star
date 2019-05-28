using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskChange : MonoBehaviour
{
    public GameObject[] mask;
    // Update is called once per frame
    void Update()
    {
        if (SelectStage.StageSelectNumber % 2 == 0)
        {
            mask[0].SetActive(true);
            mask[1].SetActive(false);
        }
        else
        {
            mask[1].SetActive(true);
            mask[0].SetActive(false);
        }
    }
}
