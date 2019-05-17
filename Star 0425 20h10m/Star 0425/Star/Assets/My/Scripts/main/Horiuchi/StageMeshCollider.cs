using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMeshCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject[] child;
    private bool enableChild;
    private GameObject gameGenerator;
    // Start is called before the first frame update
    void Start()
    {
        enableChild = true;
        gameGenerator = GameObject.Find("GameGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > gameGenerator.GetComponent<GameGenerator>().speed && enableChild)
        {
            enableChild = false;
            for (int i = 0; i < child.Length; i++)
            {
               child[i].GetComponent<Collider>().enabled = enableChild;
            }
        }
        if (transform.position.z < gameGenerator.GetComponent<GameGenerator>().speed && !enableChild)
        {
            enableChild = true;
            for (int i = 0; i < child.Length; i++)
            {
                child[i].GetComponent<Collider>().enabled = enableChild;
            }
        }
    }
}
