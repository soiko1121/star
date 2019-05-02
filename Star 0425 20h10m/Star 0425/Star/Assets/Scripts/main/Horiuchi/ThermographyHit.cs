using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermographyHit : MonoBehaviour
{
    public bool isThermography, thermographyHitNow;

    public GameObject littlePlanetOriginal;
    public GameObject planetHit;
    private GameObject[] littlePlanet;
    public int split;

    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0,2) == 0)
        {
            isThermography = true;
            littlePlanet = new GameObject[split];
            particle = GetComponent<ParticleSystem>();
        }
        else
        {
            isThermography = false;
        }
        thermographyHitNow = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Thermography")
        {
            if (isThermography)
            {
                thermographyHitNow = true;
                particle.Play();
            }
        }
        if (other.gameObject.tag == "Player" && thermographyHitNow)
        {
            planetHit.GetComponent<PlanetHit>().BurstPlanet();
            Destroy(gameObject);
        }
    }
}
