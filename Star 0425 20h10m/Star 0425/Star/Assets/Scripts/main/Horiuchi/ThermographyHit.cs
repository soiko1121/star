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

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0,2) == 0)
        {
            isThermography = true;
            littlePlanet = new GameObject[split];
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
            }
        }
        if (other.gameObject.tag == "Player" && thermographyHitNow)
        {
            planetHit.GetComponent<PlanetHit>().BurstPlanet();
            Destroy(gameObject);
        }
    }
}
