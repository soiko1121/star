using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameGenerator gameGenerator;
    public GameObject[] particles;
    public float defPosZ;
    public int maxCount = 0;
    public float maxDistanse;
    public Vector2 maxLimit;
    public Vector2 minLimit;
    public Vector3 goalMove;
    public float goalSpeed;
    public int goalMaxCount;

    private GameObject player;
    private float target;
    private Vector3 targetV3;
    private float move;
    private int saveCount;
    private int count;
    private ParticleSystem particle;
    private Vector2 pm;
    private Vector2 limit;
    private Vector2 limitTarget;
    private int goalRotaCount;

    void Start()
    {
        saveCount = 0;
        count = 0;
        player = GameObject.FindWithTag("Player");
        particle = particles[0].GetComponent<ParticleSystem>();
        limit = maxLimit;
        goalRotaCount = goalMaxCount;
    }
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (!Goal.ClearFlag)
        {
            Vector3 v3;
            if (player.transform.position.x == 0)
                v3.x = 0;
            else
                v3.x = limit.x / (player.GetComponent<PlayerMove>().limit.x / player.transform.position.x);
            if (player.transform.position.y == 0)
                v3.y = 0;
            else
                v3.y = limit.y / (player.GetComponent<PlayerMove>().limit.y / player.transform.position.y);
            v3.z = transform.position.z;

            transform.position = v3;
            transform.LookAt(player.transform.position);

            int star = gameGenerator.GetComponent<GameGenerator>().star;
            int[] changeCount = gameGenerator.musicChangeCount;
            int nowCount = 0;

            if (count == maxCount)
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
                    if (nowCount < saveCount)
                    {
                        particle = particles[0].GetComponent<ParticleSystem>();
                    }
                    else
                    {
                        particle = particles[1].GetComponent<ParticleSystem>();
                    }
                    if (changeCount[nowCount] == 0)
                        target = defPosZ;
                    else
                        target = defPosZ - maxDistanse / changeCount.Length * (nowCount + 1);
                    move = target - transform.position.z;
                    limitTarget = minLimit + (maxLimit - minLimit) / changeCount.Length * (changeCount.Length - nowCount) - limit;
                    saveCount = nowCount;
                    count = 0;
                    particle.Play();
                }
                else
                {
                    particle.Stop();
                }
            }
            else if (count < maxCount)
            {
                limit += limitTarget / maxCount;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + move / maxCount);
                count++;
            }
        }
        else
        {
            Vector3 v3;
            if (player.transform.position.x == 0)
                v3.x = 0;
            else
                v3.x = limit.x / (player.GetComponent<PlayerMove>().limit.x / player.transform.position.x);
            if (player.transform.position.y == 0)
                v3.y = 0;
            else
                v3.y = limit.y / (player.GetComponent<PlayerMove>().limit.y / player.transform.position.y);
            v3.z = transform.position.z;

            transform.position = v3;
            transform.LookAt(player.transform.position);

            int star = gameGenerator.GetComponent<GameGenerator>().star;
            int[] changeCount = gameGenerator.musicChangeCount;
            int nowCount = 0;

            if (goalRotaCount == goalMaxCount)
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
                if (changeCount[nowCount] == 0)
                    target = defPosZ;
                else
                    target = defPosZ - maxDistanse / changeCount.Length * (nowCount + 1);
                move = target * -1 - transform.position.z;
                goalRotaCount = 0;
            }
            else if (goalRotaCount < goalMaxCount)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + move / goalMaxCount);
                goalRotaCount++;
            }
        }
    }
}