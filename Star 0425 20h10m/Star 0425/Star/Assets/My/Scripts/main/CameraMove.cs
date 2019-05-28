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
    public Vector2 goalLimit;
    public AudioSource speedUp;
    public AudioSource speedDown;
    public float upSoundBasic = 0.3f;
    public float downSoundBasic = 0.5f;
    public float upSoundVolumeUp = 0.05f;
    public float downSoundVolumeDown = 0.1f;

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
    private int musicCount;
    private GameObject countCheck;

    void Start()
    {
        saveCount = 0;
        count = 0;
        player = GameObject.FindWithTag("Player");
        countCheck = GameObject.Find("GameGenerator");
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
            musicCount = countCheck.GetComponent<GameGenerator>().musicCnt;

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
                        particle = particles[0].GetComponent<ParticleSystem>();// 減速
                        speedDown.volume = downSoundBasic + downSoundVolumeDown * musicCount;
                        speedDown.PlayOneShot(speedDown.clip);
                    }
                    else
                    {
                        particle = particles[1].GetComponent<ParticleSystem>();// 加速
                        speedUp.volume = upSoundBasic + upSoundVolumeUp * musicCount;
                        speedUp.PlayOneShot(speedUp.clip);
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
                Vector3 moveV3;
                moveV3 = new Vector3(
                Mathf.Sin(Mathf.PI * 2f / (goalMaxCount * 2f) * goalRotaCount) * goalLimit.x,
                Mathf.Sin(Mathf.PI * 2f / (goalMaxCount * 2f) * goalRotaCount) * goalLimit.y,
                move / goalMaxCount);
                transform.position += moveV3;//上で代入してるから+=で大丈夫
                goalRotaCount++;
            }
            if (goalRotaCount == goalMaxCount)//二回目消し
            {
                goalRotaCount++;
            }
            transform.LookAt(player.transform.position);
        }
    }
}