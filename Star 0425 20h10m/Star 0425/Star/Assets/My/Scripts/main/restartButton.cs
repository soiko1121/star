using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadS()
    {
        SceneManager.LoadScene("LoadScene");
    } 
}
