using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject[] stage;
    public static int stageNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(stage[stageNumber], Vector3.zero, Quaternion.identity);
    }
}