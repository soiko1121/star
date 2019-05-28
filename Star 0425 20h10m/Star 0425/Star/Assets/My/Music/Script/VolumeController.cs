using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public AudioSource jingleBGM;
    public float volumeDownEffect;
    public float volumeUpEffect;
    private bool volumeSwitch;
    private VolumeControl1 volumeControl1;
    void Start()
    {
        volumeSwitch = false;
        volumeControl1 = GameObject.Find("BGMEvent2").GetComponent<VolumeControl1>();
    }
    
    void Update()
    {
        if(volumeSwitch)
        {
            for (int i = 0; i < volumeControl1.musicStep.Length; i++)
                volumeControl1.musicStep[i].volume -= volumeDownEffect;

            jingleBGM.volume += volumeUpEffect;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(volumeSwitch == false)
        {
            volumeSwitch = true;
            for (int i = 0; i < volumeControl1.musicStep.Length; i++)
                volumeControl1.musicStep[i].loop = false;
            jingleBGM.Play();
        }
    }
}
