using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private GameObject mainUI;
    private VolumeControl1 volumeControl;

    private void Start()
    {
        volumeControl = GameObject.Find("BGMEvent").GetComponent<VolumeControl1>();
    }

    public void pause()
    {
        pauseUI.SetActive(true);
        mainUI.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("ポーズしたよ");
        for (int i = 0; i < volumeControl.musicStep.Length; i++)
            volumeControl.musicStep[i].volume = 0;
        volumeControl.pauseSwich = true;
        Debug.Log(volumeControl.pauseSwich);
    }

    public void start()
    {
        pauseUI.SetActive(false);
        mainUI.SetActive(true);
        Time.timeScale = 1f;
        Debug.Log("ゲームに戻ったよ");
        volumeControl.pauseSwich = false;
        Debug.Log(volumeControl.pauseSwich);
        for (int i = 0; i < volumeControl.pauseMusicStep.Length; i++)
        {
            volumeControl.pauseMusicStep[i].volume = 0;
            volumeControl.musicStep[i].volume = volumeControl.firstVolume;// 一気に流す
        }
        
    }
}
