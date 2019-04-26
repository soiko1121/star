using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl1 : MonoBehaviour
{
    public AudioSource MusicStep_1;
    public AudioSource MusicStep_2;
    public AudioSource MusicStep_3;
    public AudioSource MusicStep_4;
    public AudioSource MusicStep_5;
    public AudioSource MusicStep_6;
    int count, maxCount;

    // Start is called before the first frame update
    void Start()
    {
        maxCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && count < maxCount)
        {
            count++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && count > 0)
        {
            count--;
        }

        switch (count)
        {
            case 0:
                Debug.Log(count);
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 0;
                MusicStep_3.volume = 0;
                MusicStep_4.volume = 0;
                MusicStep_5.volume = 0;
                MusicStep_6.volume = 0;
                break;

            case 1:
                Debug.Log(count);
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 0;
                MusicStep_4.volume = 0;
                MusicStep_5.volume = 0;
                MusicStep_6.volume = 0;
                break;

            case 2:
                Debug.Log(count);
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 1;
                MusicStep_4.volume = 0;
                MusicStep_5.volume = 0;
                MusicStep_6.volume = 0;
                break;

            case 3:
                Debug.Log(count);
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 1;
                MusicStep_4.volume = 1;
                MusicStep_5.volume = 0;
                MusicStep_6.volume = 0;
                break;

            case 4:
                Debug.Log(count);
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 1;
                MusicStep_4.volume = 1;
                MusicStep_5.volume = 1;
                MusicStep_6.volume = 0;
                break;

            case 5:
                Debug.Log(count);
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 1;
                MusicStep_4.volume = 1;
                MusicStep_5.volume = 1;
                MusicStep_6.volume = 1;
                break;

            default:
                break;
        }
    }
}
