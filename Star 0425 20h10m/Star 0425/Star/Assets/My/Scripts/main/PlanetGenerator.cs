using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject[] stage;
    public int stageNumber;
    // Start is called before the first frame update
    void Start()
    {
        //stageNumber = SelectStage.StageSelectNumber - 1;
        for (int i = 0; i < 10; i++)
            Instantiate(stage[stageNumber], new Vector3(0, 0, i * 3000), Quaternion.identity);
        //Instantiate(stage[SelectStage.StageSelect - 1], Vector3.zero, Quaternion.identity);
    }
}