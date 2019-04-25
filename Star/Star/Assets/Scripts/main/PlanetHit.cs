using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetHit : MonoBehaviour
{
    public GameObject planet;
    public GameObject littlePlanetOriginal;
    private GameObject[] littlePlanet;
    public int split;

    void Start()
    {
        //split = (int)planet.transform.localScale.x * 5;
        littlePlanet = new GameObject[split];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BurstPlanet();
            Destroy(planet);
        }
    }
    void BurstPlanet()
    {
        for (int i = 0; i < split; i++)
        {
            float distanse = Random.Range(0f, 20f) / 10;
            float angle = Random.Range(0, 36000f / split) / 100f + 360f / split * i;
            Vector3 v3 = new Vector3(
                distanse * Mathf.Cos(angle * Mathf.Deg2Rad) + transform.position.x,
                distanse * Mathf.Sin(angle * Mathf.Deg2Rad) + transform.position.y,
                transform.position.z);

            littlePlanet[i] = Instantiate(littlePlanetOriginal, v3, Quaternion.identity) as GameObject;
            littlePlanet[i].GetComponent<LittlePlanetMove>().target = transform.position;
            if (angle < 180)
            {
                littlePlanet[i].GetComponent<LittlePlanetMove>().up = true;
            }
            else
            {
                littlePlanet[i].GetComponent<LittlePlanetMove>().up = false;
            }
            if (angle < 90 || angle > 270)
            {
                littlePlanet[i].GetComponent<LittlePlanetMove>().left = false;
            }
            else
            {
                littlePlanet[i].GetComponent<LittlePlanetMove>().left = true;
            }
        }
    }
}
