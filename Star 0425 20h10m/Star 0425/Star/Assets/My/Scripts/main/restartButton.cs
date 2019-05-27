using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartButton : MonoBehaviour
{
    public GameObject dialog;
    public GameObject backB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void retryDia()
    {
        backB.SetActive(false);
        dialog.SetActive(true);
    }
    public void diaClose()
    {
        backB.SetActive(true);
        dialog.SetActive(false);
    }

    public void loadS()
    {
        Time.timeScale = 1.0f;
        Resources.UnloadUnusedAssets();//一回全部消し飛ばすやつ　by亀
        SceneManager.LoadScene("LoadScene");
    } 
}
