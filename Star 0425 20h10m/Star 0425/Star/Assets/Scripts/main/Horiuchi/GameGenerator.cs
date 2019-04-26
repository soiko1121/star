using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public GameObject planetMove;
    public GameObject bulackHole;
    public int star = 0;
    public float distance, speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (star >= 0 && star < 30)
        {
            speed = 3;
        }
        else if (star < 60)
        {
            speed = 4;
        }
        else if (star < 100)
        {
            speed = 5;
        }
        else if (star < 150)
        {
            speed = 7;
        }
        else if(star < 200)
        {
            speed = 8;
        }
        else if(star < 250)
        {
            speed = 9;
        }
        else
        {
            speed = 10;
        }
        distance += speed / 30.0f;
        planetMove.GetComponent<PlanetMove>().speed = speed;
        bulackHole.GetComponent<PlanetMove>().speed = speed;
    }
}
