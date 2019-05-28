using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingMove : MonoBehaviour
{
    private Object[] allObject;
    private int stockNumber;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void RankingButtonOnClick()
    {
        stockNumber = SelectStage.StageSelectNumber;
        allObject = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        SceneManager.LoadScene("RankingScene", LoadSceneMode.Additive);
        foreach (GameObject gameObject in allObject)
        {
            if (gameObject.tag == "UI" || gameObject.tag == "SubUI")
            {
                gameObject.SetActive(false);
            }
        }

    }

    private void OnSceneUnloaded(Scene current)
    {
        if (current.name == "RankingScene")
        {
            SelectStage.StageSelectNumber = stockNumber;
            allObject = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            foreach (GameObject gameObject in allObject)
            {
                if (gameObject.tag == "UI")
                    gameObject.SetActive(true);
            }
        }
    }
}
