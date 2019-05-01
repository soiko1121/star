using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 oldPos;
    private GameObject player;

    void Start()
    {
        oldPos = Vector3.zero;
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Vector3 v3 = player.transform.position - oldPos;
        transform.position += new Vector3(v3.x / 4.0f, v3.y / 4.0f);
        oldPos = player.transform.position;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, -5 - (GameGenerator.Star / 5 * 0.5f));
    }
}