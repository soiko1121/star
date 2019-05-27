using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnTitle : MonoBehaviour
{
    private int stock;
    private GameObject 
        button,
        bgm;
    private void Start()
    {
        stock = SelectStage.StageSelectNumber;
        button = GameObject.Find("ButtonSE");
        bgm = GameObject.Find("BGM");
    }
    public void ReturnTitle()
    {
        Time.timeScale = 1f;
        button.GetComponent<ButtonDontDestroy>().DestroyThisObject();
        bgm.GetComponent<ButtonDontDestroy>().DestroyThisObject();
        SceneManager.LoadScene("TitleScene");
    }

    public void Retry()
    {
        SelectStage.StageSelectNumber = stock;
        Time.timeScale = 1f;
        bgm.GetComponent<ButtonDontDestroy>().DestroyThisObject();
        Resources.UnloadUnusedAssets();//一回全部消し飛ばすやつ　by亀
        SceneManager.LoadScene("LoadScene");
    }
}
