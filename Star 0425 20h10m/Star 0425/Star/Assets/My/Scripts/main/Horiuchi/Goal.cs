using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private int goalCount;
    public static bool ClearFlag
    {
        get; set;
    }

    private void Start()
    {
        ClearFlag = false;
        goalCount = 999;
    }
    private void Update()
    {
        if (goalCount < 600)
        {
            goalCount++;
            if (goalCount == 600)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
            goalCount = 0;
            ClearFlag = true;
        }
    }
}
