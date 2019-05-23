using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single_SEControl : MonoBehaviour
{
    private AudioSource myAudio;

    void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GetSingleSe()
    {
        myAudio.PlayOneShot(myAudio.clip);
    }

}
