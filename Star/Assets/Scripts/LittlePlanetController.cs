using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePlanetController : MonoBehaviour
{
    private GameObject[] littlePlanets = new GameObject[100];
    public List<int> TagList
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        TagList = new List<int>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        littlePlanets = GameObject.FindGameObjectsWithTag("MiniStar");
        for (int i = 0; i < littlePlanets.Length; i++)
        {
            int max = littlePlanets[i].GetComponent<LittlePlanetMove>().Number;
            for (int k = i; k < littlePlanets.Length; k++)
            {
                if (max > littlePlanets[k].GetComponent<LittlePlanetMove>().Number &&
                    littlePlanets[k].GetComponent<LittlePlanetMove>().Number != -1)
                {
                    GameObject gameObject = littlePlanets[i];
                    littlePlanets[i] = littlePlanets[k];
                    littlePlanets[k] = gameObject;
                    max = littlePlanets[k].GetComponent<LittlePlanetMove>().Number;
                }
                if (max == i)
                    break;
            }
        }
        for (int i = 0; i < littlePlanets.Length; i++)
        {
            littlePlanets[i].GetComponent<LittlePlanetMove>().Number = i;
        }
        //count = (count + 1) % 60;
        //if (count == 0)
        //{
        //    for (int i = 0; i < littlePlanets.Length; i++)
        //    {
        //        int newNumber = Random.Range(0, littlePlanets.Length - 1);
        //        int number = littlePlanets[i].GetComponent<LittlePlanetMove>().Number;
        //        littlePlanets[i].GetComponent<LittlePlanetMove>().Number = littlePlanets[newNumber].GetComponent<LittlePlanetMove>().Number;
        //        littlePlanets[newNumber].GetComponent<LittlePlanetMove>().Number = number;
        //    }
        //}
    }
    int count = 0;
}
