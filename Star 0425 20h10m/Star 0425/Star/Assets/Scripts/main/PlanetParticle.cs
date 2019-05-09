using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetParticle : MonoBehaviour
{
    private ParticleSystem particle;
    public GameObject effectObject;
    // Start is called before the first frame update
    void Start()
    {

        particle = effectObject.GetComponent<ParticleSystem>();
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
