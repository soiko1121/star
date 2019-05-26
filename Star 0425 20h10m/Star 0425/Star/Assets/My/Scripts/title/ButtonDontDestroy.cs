using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
