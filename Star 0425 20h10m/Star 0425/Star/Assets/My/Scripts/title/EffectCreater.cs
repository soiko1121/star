using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreater : MonoBehaviour
{
    [SerializeField]
    ParticleSystem effect;
    [SerializeField]
    Camera effectCamera;
    [SerializeField]
    ParticleSystem myParticleSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = effectCamera.ScreenToWorldPoint(Input.mousePosition + effectCamera.transform.forward * 10);
            effect.transform.position = pos;
            effect.Emit(1);      
        }

        myParticleSystem.Simulate(Time.unscaledDeltaTime, false, false);
    }
}
