using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    public GameGenerator gameGenerator;
    public int constant;
    public int percentage;
    public int protectTime;
    private GameObject[] littlePlanets;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }
    private void Update()
    {
        if (count < protectTime)
        {
            count++;
            //gameObject.GetComponent<PlayerMove>().anime.SetBool("IsDamage", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DangerObject")
        {
            if (count == protectTime)
            {
                if (SystemInfo.supportsVibration)
                {
                    Handheld.Vibrate();
                }
                if (gameGenerator.GetComponent<GameGenerator>().star <= 0)
                {
                    SceneManager.LoadScene("ResultScene");
                }
                littlePlanets = GameObject.FindGameObjectsWithTag("MiniStar");
                int length = constant + littlePlanets.Length / percentage;
                if (length > littlePlanets.Length)
                {
                    length = littlePlanets.Length;
                }

                for (int i = 0; i < length; i++)
                {
                    Destroy(littlePlanets[i]);
                    gameGenerator.GetComponent<GameGenerator>().star--;
                }
                count = 0;
                //gameObject.GetComponent<PlayerMove>().anime.SetBool("IsDamage", true);
            }
        }
    }
}
