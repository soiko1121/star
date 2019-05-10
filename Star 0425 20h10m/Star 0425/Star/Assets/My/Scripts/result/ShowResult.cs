using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text resultScore = GetComponent<Text>();

        int score = GameGenerator.Star;
        resultScore.text = score.ToString();
    }
}
