using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMove : MonoBehaviour
{
    private GameObject gameGenerator;
    // Start is called before the first frame update
    void Start()
    {
        gameGenerator = GameObject.Find("GameGenerator");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameGenerator.GetComponent<TimeGenerator>().zoneHit = true;
            Destroy(gameObject);
        }
    }
}
