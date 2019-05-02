using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermography : MonoBehaviour
{
    public GameObject thermographyOriginal;
    private GameObject thermography;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!DebugPC.pc)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                thermography = Instantiate(thermographyOriginal, transform.position, Quaternion.identity) as GameObject;
            }
        }
    }
}