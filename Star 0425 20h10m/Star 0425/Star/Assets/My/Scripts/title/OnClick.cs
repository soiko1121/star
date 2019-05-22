using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    private GameObject buttonSe;
    // Start is called before the first frame update
    void Start()
    {
        buttonSe = GameObject.Find("ButtonSE");
    }

    public void Onclick()
    {
        buttonSe.GetComponent<SEControl_Button>().ButtonSe();
    }
}
