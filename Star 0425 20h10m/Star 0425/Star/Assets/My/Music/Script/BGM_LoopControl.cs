using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_LoopControl : MonoBehaviour
{
    public AudioClip audio;
    public AudioClip audio_loop;
    private AudioSource audioSource;
    private int onSwitch = 0;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audio;
        audioSource.Play();// 冒頭を再生
    }
     
    void Update()
    {
        if(!audioSource.isPlaying && onSwitch==0)
        {
            audioSource.clip = audio_loop;
            audioSource.loop = true;
            audioSource.Play();
            onSwitch = 1;
        }
    }
}
