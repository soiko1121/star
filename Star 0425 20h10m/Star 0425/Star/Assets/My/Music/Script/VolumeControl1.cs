using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl1 : MonoBehaviour
{
    public float firstVolume = 0.2f;// ポーズから復帰したときのBGMの初期音量
    public AudioSource[] musicStep;
    public AudioSource[] pauseMusicStep;
    private GameObject gameGenerator;
    private int musicCount;
    public bool pauseSwich = false;
    private float crescendoVolumeNumber;

    // Start is called before the first frame update
    void Start()
    {
        gameGenerator = GameObject.Find("GameGenerator");
        crescendoVolumeNumber = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        musicCount = gameGenerator.GetComponent<GameGenerator>().musicCnt;

        if (pauseSwich)
        {
            for (int i = 0; i < musicCount + 1; i++)
                if (pauseMusicStep[i].volume < 0.3f)
                    pauseMusicStep[i].volume = 0.3f;
            for (int i = musicCount + 1; i < musicStep.Length; i++)
                pauseMusicStep[i].volume = 0;
        }
        else
        {
            for (int i = 0; i < musicCount + 1; i++)
                    musicStep[i].volume += crescendoVolumeNumber;
            for (int i = musicCount + 1; i < musicStep.Length; i++)
                musicStep[i].volume = 0;
        }
    }
}
