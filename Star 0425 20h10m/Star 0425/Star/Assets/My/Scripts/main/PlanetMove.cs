using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    private Rigidbody planetRB;
    public float speed;
    public float set2DSpeed;
    private GameObject gameGenerator;
    private PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        planetRB = GetComponent<Rigidbody>();
        set2DSpeed = transform.position.x / 60.0f;
        gameGenerator = GameObject.Find("GameGenerator");
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        planetRB.velocity = Vector3.back * gameGenerator.GetComponent<GameGenerator>().speed;
        if (transform.position.z < -10 && tag != ("Goal"))
        {
            Destroy(gameObject);
        }
    }
}