using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneLoad()
    {
        SceneManager.LoadScene("ResultScene");
        Time.timeScale = 1f;
    }
}
