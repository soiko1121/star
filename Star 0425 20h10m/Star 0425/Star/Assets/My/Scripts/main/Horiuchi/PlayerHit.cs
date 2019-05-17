using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    public GameGenerator gameGenerator;
    public GameObject model;
    public int constant;
    public int percentage;
    public int protectTime;
    private GameObject[] littlePlanets;
    private bool dangerHit;
    private int count;

    private ParticleSystem particle;
    [SerializeField]
    private GameObject effectObject;
    public static bool Hit
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        dangerHit = false;
        Hit = false;
        particle = effectObject.GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (count < protectTime)
        {
            count++;
        }
        else if (count == protectTime)
        {
            Hit = false;
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
                if (gameGenerator.star <= 0)
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
                }
                count = 0;
                dangerHit = true;
                Hit = true;
                model.GetComponent<MyAnimator>().Hit = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GirigiriZone")
        {
            if (!dangerHit)
            {
                if (count == protectTime)
                {
                    gameGenerator.addSpeedTimer = 3;
                    particle.Play();
                }
            }
            else
            {
                dangerHit = false;
            }
        }
    }
}
