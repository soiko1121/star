using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject[] stage;
    public static int stageNumber;
    //public int stageNumber;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(stage[stageNumber], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(stage[stageNumber], Vector3.zero, Quaternion.identity);
    }
}