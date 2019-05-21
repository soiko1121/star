using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEControl_Button : MonoBehaviour
{
    private AudioSource audioController;
    void Start()
    {
        audioController = gameObject.GetComponent<AudioSource>();
    }
    public void ButtonSe()
    {
        audioController.PlayOneShot(audioController.clip);
    }
}
