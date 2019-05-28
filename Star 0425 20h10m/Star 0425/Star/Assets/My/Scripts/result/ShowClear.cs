using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowClear : MonoBehaviour
{
    public GameObject[] result;
    Image clear;
    // Start is called before the first frame update
    void Start()
    {
        if (TotalScore.IsClear == true)
        {
            result[0].SetActive(true);
            result[1].SetActive(false);
        }
        else
        {
            result[1].SetActive(true);
            result[0].SetActive(false);
        }
    }
}
