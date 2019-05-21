using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject[] stage;
    //public int stageNumber;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(stage[stageNumber], Vector3.zero, Quaternion.identity);
        Instantiate(stage[SelectStage.StageSelectNumber - 1], Vector3.zero, Quaternion.identity);
    }
}