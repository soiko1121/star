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
    private GameObject gameGenerator;

    // Start is called before the first frame update
    void Start()
    {
        gameGenerator = GameObject.Find("GameGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameGenerator.GetComponent<GameGenerator>().musicCnt)
        {
            case 0:
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 0;
                MusicStep_3.volume = 0;
                MusicStep_4.volume = 0;
                MusicStep_5.volume = 0;
                MusicStep_6.volume = 0;
                break;

            case 1:
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 0;
                MusicStep_4.volume = 0;
                MusicStep_5.volume = 0;
                MusicStep_6.volume = 0;
                break;

            case 2:
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 1;
                MusicStep_4.volume = 0;
                MusicStep_5.volume = 0;
                MusicStep_6.volume = 0;
                break;

            case 3:
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 1;
                MusicStep_4.volume = 1;
                MusicStep_5.volume = 0;
                MusicStep_6.volume = 0;
                break;

            case 4:
                MusicStep_1.volume = 1;
                MusicStep_2.volume = 1;
                MusicStep_3.volume = 1;
                MusicStep_4.volume = 1;
                MusicStep_5.volume = 1;
                MusicStep_6.volume = 0;
                break;

            case 5:
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
