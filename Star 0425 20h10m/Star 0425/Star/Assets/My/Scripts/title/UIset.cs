using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIset : MonoBehaviour
{
    [SerializeField]
    GameObject firstUI;
    [SerializeField]
    GameObject secondUI;
    [SerializeField]
    GameObject htUI;

    public static bool onceActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!onceActive)
        {
            firstUI.SetActive(true);
            secondUI.SetActive(false);
            onceActive = true;
        }
        else
        {
            firstUI.SetActive(false);
            secondUI.SetActive(true);
        }
        htUI.SetActive(false);
    }
}