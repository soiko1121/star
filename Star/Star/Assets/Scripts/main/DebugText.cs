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
        //GetComponent<Text>().text = "X:" + debugVec3.x.ToString() + "\nY:" + debugVec3.y.ToString() + "\nZ:" + debugVec3.z.ToString();
        //GetComponent<Text>().text = "X:" + debugQuater.x.ToString() + "\nY:" + debugQuater.y.ToString() + "\nZ:" + debugQuater.z.ToString() + "\nW:" + debugQuater.w.ToString();
        GetComponent<Text>().text = text.ToString();
    }
}
