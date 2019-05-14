using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowtoController : MonoBehaviour
{
    [SerializeField]
    GameObject UDui;
    [SerializeField]
    GameObject LRui;

    [SerializeField]
    Button LButton;
    [SerializeField]
    Button RButton;

    int imageState;

    // Start is called before the first frame update
    void Start()
    {
        imageState = 1;

        LButton.onClick.AddListener(changeImage);
        RButton.onClick.AddListener(changeImage);
    }

    // Update is called once per frame
    void Update()
    {
        if(imageState == 1)
        {
            UDui.SetActive(true);
            LRui.SetActive(false);
        }
        else
        {
            UDui.SetActive(false);
            LRui.SetActive(true);
        }
    }

    void changeImage()
    {
        imageState *= -1;
    }
}
