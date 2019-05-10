using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRange : MonoBehaviour
{
    public DebugText debugText;
    public Material nomalMaterial, hitMaterial;
    public float range;
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TopObject" || collision.gameObject.name == "BottomObject")
        {    
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0.0f, 0.0f);
            collision.gameObject.GetComponent<Renderer>().material = hitMaterial;
        }
        if (collision.gameObject.name == "RightObject" || collision.gameObject.name == "LeftObject")
        {
            playerRB.velocity = new Vector3(0.0f, playerRB.velocity.y, 0.0f);
            collision.gameObject.GetComponent<Renderer>().material = hitMaterial;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<Renderer>().material = nomalMaterial;
    }
}
