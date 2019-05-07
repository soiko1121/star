using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    public GameGenerator gameGenerator;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }
    private void Update()
    {
        if (count < 60)
        {
            count++;
            gameObject.GetComponent<PlayerMove>().anime.SetBool("IsDamage", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DangerObject")
        {
            if (SystemInfo.supportsVibration)
            {
                Handheld.Vibrate();
                gameObject.GetComponent<PlayerMove>().anime.SetBool("IsDamage", true);
            }
            if (gameGenerator.GetComponent<GameGenerator>().star <= 0)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
