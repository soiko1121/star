using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToCon : MonoBehaviour
{
    public GameObject howTo;
    public GameObject other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHowTo()
    {
        howTo.SetActive(true);
        other.SetActive(false);
    }
    public void endHowTo()
    {
        howTo.SetActive(false);
        other.SetActive(true);
    }
}
