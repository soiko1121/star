using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InVolumeControl : MonoBehaviour
{
    public AudioSource kirakira;
    public float volumeUp = 0.04f;
    public float volumeDown = 0.04f;
    public float maxVolume = 0.6f;
    public bool touchSwitch = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (touchSwitch)
            if (kirakira.volume < maxVolume)
                kirakira.volume += volumeUp;
            else
                kirakira.volume = maxVolume;
        else
            kirakira.volume -= volumeDown;
    }
}
