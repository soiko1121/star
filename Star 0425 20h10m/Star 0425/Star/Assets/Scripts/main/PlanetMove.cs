using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    Rigidbody planetRB;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        planetRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        planetRB.AddForce(Vector3.back * speed);
        if (transform.position.z < -5)
        {
            Destroy(gameObject);
        }
    }
}
