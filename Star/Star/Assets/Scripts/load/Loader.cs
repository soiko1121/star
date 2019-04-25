using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    AsyncOperation async;

    [SerializeField] Slider slider;
    [SerializeField] GameObject UI;

    public void Start()
    {
        slider.enabled = false;
        UI.SetActive(false);
    }

    public void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                slider.enabled = true;
                StartCoroutine("LoadData");
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    slider.enabled = true;
                    StartCoroutine("LoadData");
                }
            }
        }   
    }

    IEnumerator LoadData()
    {
        async = SceneManager.LoadSceneAsync("MainScene");

        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }
}
