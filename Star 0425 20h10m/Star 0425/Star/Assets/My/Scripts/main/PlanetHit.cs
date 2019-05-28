using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetHit : MonoBehaviour
{
    public GameObject littlePlanetOriginal;
    public GameObject partOriginal;
    public GameObject[] littlePlanet;
    public int split;

    private GameObject player;
    private bool hit;
    private GameObject part;
    private GameObject hitSe;
    void Start()
    {
        //split = (int)planet.transform.localScale.x * 5;
        littlePlanet = new GameObject[split];
        player = GameObject.FindWithTag("Player");
        hitSe = GameObject.Find("SE");
        hit = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player" || (other.gameObject.tag == "MiniStar" && other.gameObject.GetComponent<LittlePlanetMove>().Hit)) && !hit)
        {
            BurstPlanet();
            hit = true;
            part = Instantiate(partOriginal, transform.position, Quaternion.identity) as GameObject;
            hitSe.transform.GetChild(0).GetComponent<SEControl_Crystal>().GetCrystalSe();
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject);
        }
    }
    public void BurstPlanet()
    {
        for (int i = 0; i < split; i++)
        {
            float distanse = Random.Range(0f, 20f) / 10;
            float angle = Random.Range(0, 36000f / split) / 100f + 360f / split * i;
            Vector3 v3;
            if (player.GetComponent<PlayerMove>().viewSet == PlayerMove.View.back)
            {
                v3 = new Vector3(
                                distanse * Mathf.Cos(angle * Mathf.Deg2Rad) + transform.position.x,
                                distanse * Mathf.Sin(angle * Mathf.Deg2Rad) + transform.position.y,
                                transform.position.z);
            }
            else
            {
                v3 = new Vector3(
                                transform.position.x,
                                distanse * Mathf.Sin(angle * Mathf.Deg2Rad) + transform.position.y,
                                -Mathf.Abs(distanse * Mathf.Cos(angle * Mathf.Deg2Rad)) + transform.position.z);
            }

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