using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    public Vector3 debugVec3 = Vector3.zero;
    public Quaternion debugQuater = Quaternion.identity;
    public bool hit;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = text.ToString();
    }
}
