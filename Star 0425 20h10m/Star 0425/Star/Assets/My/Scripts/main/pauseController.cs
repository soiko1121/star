using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private GameObject mainUI;

    private void Start()
    {

    }

    public void pause()
    {
        pauseUI.SetActive(true);
        mainUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void start()
    {
        pauseUI.SetActive(false);
        mainUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
