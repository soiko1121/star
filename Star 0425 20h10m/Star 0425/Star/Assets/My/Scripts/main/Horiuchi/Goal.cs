using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
            }
                SceneManager.LoadScene("ResultScene");
        }
    }
}
