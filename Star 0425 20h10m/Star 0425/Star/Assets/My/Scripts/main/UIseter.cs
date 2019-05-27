using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIseter : MonoBehaviour
{
    public GameObject[] UIs;

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 1; i < UIs.Length; i++)
        {
            UIs[i].SetActive(false);
        }
    }
}
