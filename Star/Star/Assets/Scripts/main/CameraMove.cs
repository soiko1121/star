using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 oldPos;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        oldPos = Vector3.zero;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = player.transform.position - oldPos;
        transform.position += new Vector3(v3.x / 2.0f, v3.y / 1.3f);
        oldPos = player.transform.position;
    }
}