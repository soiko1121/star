using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneStart()
    {
        if (Application.isEditor)
        {
            Resources.UnloadUnusedAssets();//一回全部消し飛ばすやつ　by亀
            SceneManager.LoadScene("SelectScene");
        }
    }
}
    