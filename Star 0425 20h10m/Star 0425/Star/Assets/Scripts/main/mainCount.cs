using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCount : MonoBehaviour
{
    public static int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count = GameObject.FindGameObjectsWithTag("sphere").Length;
    }

    public static int getCount()
    {
        return count;
    }
}
