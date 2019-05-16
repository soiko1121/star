using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl1 : MonoBehaviour
{
    public AudioSource[] musicStep;
    private GameObject gameGenerator;
    private int musicCnt;
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
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        musicCnt = gameGenerator.GetComponent<GameGenerator>().musicCnt;
        if (musicCnt == 0)
        {
            for (int i = 0; i < musicCnt + 1; i++)
                musicStep[i].volume = 1;
            for (int i = musicCnt + 1; i < musicStep.Length; i++)
                musicStep[i].volume = 0;
        }
        else
        {
            for (int i = 1; i < musicCnt + 1; i++)
                musicStep[i].volume += crescendoVolumeNumber;
            for (int i = musicCnt + 1; i < musicStep.Length; i++)
                musicStep[i].volume = 0;
        }
      
    }
}
