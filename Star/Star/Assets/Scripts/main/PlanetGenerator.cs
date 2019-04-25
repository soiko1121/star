using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject[] stage;
    public Vector3 min, max;
    public int second;
    public float depth;
    private GameObject planet;
    private GameObject dangerObject;
    private GameObject player;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        second *= 60;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (count == 0)
        //{
        //    int indexMax = Random.Range(1, 4);
        //    for (int i = 0; i < indexMax; i++)
        //    {
        //        Vector3 v3 = new Vector3(Random.Range(min.x, max.x) / 10f, Random.Range(min.y, max.y) / 10f, player.transform.position.z + depth);
        //        int size = Random.Range(1, 4);
        //        if (Random.Range(0, 2) == 1)
        //        {
        //            planet = Instantiate(planetOriginal, v3, Quaternion.identity) as GameObject;
        //            planet.GetComponent<PlanetHit>().split = size * 10;
        //            planet.transform.localScale *= size;
        //        }
        //        else
        //        {
        //            dangerObject = Instantiate(dangerObjectOriginal, v3, Quaternion.identity) as GameObject;
        //            dangerObject.transform.localScale *= size;
        //        }
        //    }
        //}

        if (count % second == 0)
        {
            Vector3 v3 = new Vector3(0, 0, 5);
            planet = Instantiate(stage[count / second - 1], Vector3.zero, Quaternion.identity) as GameObject;
        }
        //planet.GetComponent<PlanetHit>().split = size * 10;
        //planet.transform.localScale *= size;
        count = (count + 1) % (second * stage.Length);
    }
}