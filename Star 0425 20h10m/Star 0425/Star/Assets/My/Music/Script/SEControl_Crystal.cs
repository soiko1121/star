using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEControl_Crystal : MonoBehaviour
{
    public AudioClip[] clipSE;
    private AudioSource audioController;
    private int mycount;
    private GameObject gameGenerator;
    private int musicCount;
    public float basicVolume = 0.5f;
    public float upVolume = 0.1f;

    void Start()
    {
        gameGenerator = GameObject.Find("GameGenerator");
        audioController = gameObject.GetComponent<AudioSource>();
        mycount = 0;
    }
    void Update()
    {
        musicCount = gameGenerator.GetComponent<GameGenerator>().musicCnt;
    }
        public void GetCrystalSe()
    {
        audioController.volume = musicCount * upVolume + basicVolume;
        //Debug.Log(audioController.volume);
        audioController.PlayOneShot(clipSE[mycount]);
        if (mycount != clipSE.Length)
            mycount++;
        if (mycount == clipSE.Length)
            mycount = 0;
    }
    public void GetPlanetHitSe()
    {
        audioController.volume = musicCount * upVolume + basicVolume;
        audioController.PlayOneShot(clipSE[mycount]);
        if (mycount != clipSE.Length)
            mycount++;
        if (mycount == clipSE.Length)
            mycount = 0;
    }
}
