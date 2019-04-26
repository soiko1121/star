using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCount : MonoBehaviour
{
    public GameGenerator gameGenerator;
    private int getStarCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getStarCount = gameGenerator.GetComponent<GameGenerator>().star;
        GetComponent<Text>().text = "Star:" + getStarCount.ToString();
    }
}
