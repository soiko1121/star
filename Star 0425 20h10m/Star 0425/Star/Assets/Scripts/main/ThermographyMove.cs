using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermographyMove : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        if (transform.localScale.x < 5)
        {
            transform.localScale *= 1.2f;
        }
        else
            Destroy(gameObject);
    }
}
