using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public static bool ClearFlag
    {
        get; set;
    }

    private void Start()
    {
        ClearFlag = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }

            ClearFlag = true;
            SceneManager.LoadScene("ResultScene");
        }
    }
}
