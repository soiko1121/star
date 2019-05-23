using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEControl_Crystal : MonoBehaviour
{
    public AudioClip[] clipSE;
    private AudioSource audioController;
    private int mycount;

    void Start()
    {
        audioController = gameObject.GetComponent<AudioSource>();
        mycount = 0;
    }

    public void GetCrystalSe()
    {
        audioController.PlayOneShot(clipSE[mycount]);
        if (mycount != clipSE.Length)
            mycount++;
        if (mycount == clipSE.Length)
            mycount = 0;
    }
}
