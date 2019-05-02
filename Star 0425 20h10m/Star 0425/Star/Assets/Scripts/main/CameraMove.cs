using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameGenerator gameGenerator;
    public float defPosZ;
    public int maxCount;
    private Vector3 oldPos;
    private GameObject player;
    private float target;
    private float move;
    private int saveCount;
    private int count;

    void Start()
    {
        saveCount = 0;
        count = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y, defPosZ);
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
        int[] changeCount = gameGenerator.musicChangeCount;
        int nowCount = 0;
        if (count == 60)
        {
            for (int i = 0; i < changeCount.Length; i++)
            {
                if (star >= changeCount[i])
                {
                    nowCount = i;
                }
                else
                {
                    break;
                }
            }
            if (nowCount != saveCount)
            {
                if (changeCount[nowCount] == 0)
                    target = defPosZ;
                else
                    target = (defPosZ - (changeCount[nowCount] / 8f));
                Debug.Log(transform.position.z);
                move = target - transform.position.z;
                saveCount = nowCount;
                count = 0;
            }
        }
        else if (count < maxCount)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + move / maxCount);
            count++;
        }
    }
}
