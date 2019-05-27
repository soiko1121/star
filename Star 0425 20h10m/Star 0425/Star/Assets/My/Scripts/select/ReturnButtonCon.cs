using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButtonCon : MonoBehaviour
{
    private GameObject 
        titleBGM,
        button;
    private void Start()
    {
        titleBGM = GameObject.Find("BGM");
        button = GameObject.Find("ButtonSE");
    }
    public void retrunT()
    {
        titleBGM.GetComponent<ButtonDontDestroy>().DestroyThisObject();
        button.GetComponent<ButtonDontDestroy>().DestroyThisObject();
        Invoke("loadT", 0.5f);
    }
    private void loadT()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
