using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject[] stage;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(stage[SelectStage.StageSelectNumber - 1], Vector3.zero,Quaternion.identity);
    }
}