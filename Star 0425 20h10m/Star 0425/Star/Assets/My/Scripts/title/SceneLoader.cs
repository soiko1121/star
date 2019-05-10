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
            SceneManager.LoadScene("LoadScene");
        }
    }
}
    