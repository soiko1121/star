using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEControl_Crystal : MonoBehaviour
{
    public AudioClip
        clip1,
        clip2,
        clip3;
    private AudioSource audioController;
    private int mycount;

    void Start()
    {
        audioController = gameObject.GetComponent<AudioSource>();
        mycount = 0;
    }

    public void GetCrystalSe()
    {
        Debug.Log(mycount);
        if (mycount == 0)
        {
            audioController.PlayOneShot(clip1);
            Debug.Log("kiteru");
            mycount = 1;
        }
        else if (mycount == 1)
        {
            audioController.PlayOneShot(clip2);
            mycount = 2;
        }
        else if (mycount == 2)
        {
            audioController.PlayOneShot(clip3);
            mycount = 0;
        }
    }
}
