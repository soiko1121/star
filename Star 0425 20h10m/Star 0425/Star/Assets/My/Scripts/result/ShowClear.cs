using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowClear : MonoBehaviour
{
    Image clear;
    // Start is called before the first frame update
    void Start()
    {
        clear = GetComponent<Image>();

        if (Goal.ClearFlag == true)
        {
            clear.enabled = true;
        }
        else
        {
            clear.enabled = false;
        }
    }

}
