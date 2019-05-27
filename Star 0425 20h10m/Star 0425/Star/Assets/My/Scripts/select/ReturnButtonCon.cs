using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButtonCon : MonoBehaviour
{
    public void retrunT()
    {
        Invoke("loadT", 0.5f);
    }
    private void loadT()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
