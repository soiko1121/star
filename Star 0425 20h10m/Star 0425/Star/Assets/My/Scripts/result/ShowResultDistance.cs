using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResultDistance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text resultScore = GetComponent<Text>();
        resultScore.text = GameGenerator.StageTimer.ToString("f2") + " km";
    }
}
