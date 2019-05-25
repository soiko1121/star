using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnTitle : MonoBehaviour
{
    private int stock;
    private void Start()
    {
        stock = SelectStage.StageSelectNumber;
    }
    public void ReturnTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    public void Retry()
    {
        SelectStage.StageSelectNumber = stock;
        Time.timeScale = 1f;
        Resources.UnloadUnusedAssets();//一回全部消し飛ばすやつ　by亀
        SceneManager.LoadScene("LoadScene");
    }
}
