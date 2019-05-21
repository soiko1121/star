using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingReturn : MonoBehaviour
{
    public void ReturnOnClick()
    {
        SceneManager.UnloadSceneAsync("RankingScene");
    }
}
