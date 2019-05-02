using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameGenerator gameGenerator;
    private Vector3 oldPos;
    private GameObject player;
    private float target;
    private int saveCount;
    private int count;

    void Start()
    {
        saveCount = 0;
        count = 0;
        oldPos = Vector3.zero;
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Vector3 v3 = player.transform.position - oldPos;
        transform.position += new Vector3(v3.x / 4.0f, v3.y / 4.0f);
        oldPos = player.transform.position;
        transform.LookAt(player.transform.position);
        int star = gameGenerator.GetComponent<GameGenerator>().star;
        if (star / 25 != saveCount && count == 60)
        {
            target = (-5 - (star / 5 * 0.4f)) - transform.position.z;
            saveCount = star / 25;
            count = 0;
        }
        if (count < 60)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + target / 60f);
            count++;
        }
    }
}