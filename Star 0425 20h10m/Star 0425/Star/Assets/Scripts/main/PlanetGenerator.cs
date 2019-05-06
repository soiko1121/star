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
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (count % second == 0)
        {
            Vector3 v3 = new Vector3(0, 0, 5);
            planet = Instantiate(stage[count / second], Vector3.zero, Quaternion.identity) as GameObject;
        }
        count = (count + 1) % (second * stage.Length);
    }
}