using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingMove : MonoBehaviour
{
    private Object[] allObject;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void RankingButtonOnClick()
    {
        allObject = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject gameObject in allObject)
        {
            if (gameObject.tag == "UI")
            {
                gameObject.SetActive(false);
            }
        }
        SceneManager.LoadScene("RankingScene", LoadSceneMode.Additive);
    }

    private void OnSceneUnloaded(Scene current)
    {
        if (current.name == "RankingScene")
        {
            allObject = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            foreach (GameObject gameObject in allObject)
            {
                gameObject.SetActive(true);
            }
        }
    }
}
