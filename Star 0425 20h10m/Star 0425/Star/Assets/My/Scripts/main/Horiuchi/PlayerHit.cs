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
    private GameObject hitSe;
    private bool dangerHit;
    private int count;

    private ParticleSystem particle;
    [SerializeField]
    private GameObject effectObject;
    public AudioSource audioSource;
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
        hitSe = GameObject.Find("SE");
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
                littlePlanets = GameObject.FindGameObjectsWithTag("MiniStar");
                if (littlePlanets.Length <= 0)
                {
                    SceneManager.LoadScene("ResultScene");
                    return;
                }
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
                //model.GetComponent<MyAnimator>().Hit = true;
                hitSe.transform.GetChild(1).GetComponent<SEControl_Crystal>().GetPlanetHitSe();
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
                    audioSource.PlayOneShot(audioSource.clip);
                }
            }
            else
            {
                dangerHit = false;
            }
        }
    }
}
