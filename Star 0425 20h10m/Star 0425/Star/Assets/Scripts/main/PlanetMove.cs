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
    private bool hitNow = false;
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
        if (gameGenerator.GetComponent<TimeGenerator>().cameraMoveNow)
        {
            if (playerMove.viewSet == PlayerMove.View.side)
            {
                transform.position = new Vector3(transform.position.x - set2DSpeed, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + set2DSpeed, transform.position.y, transform.position.z);
                GetComponent<Renderer>().enabled = true;
                GetComponent<Collider>().enabled = true;
            }
        }
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        planetRB.velocity = Vector3.back * gameGenerator.GetComponent<GameGenerator>().speed;
        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PointObject" || other.gameObject.tag == "DangerObject")
        {
            if (other.GetComponent<PlanetMove>().set2DSpeed > set2DSpeed)
            {
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}