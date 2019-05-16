using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    bool touchFlag;

    AsyncOperation async;

    [SerializeField] Slider slider;
    [SerializeField] GameObject _UI;
    [SerializeField] GameObject _Button;
    [SerializeField] Button stButton;
    [SerializeField] Image rotUI;

    public void Start()
    {
        touchFlag = false;
        slider.enabled = false;
        //_UI.SetActive(false);
        _Button.SetActive(false);
        stButton.onClick.AddListener(tapStart);
    }

    public void Update()
    {
        if (Application.isEditor)
        {
            if (touchFlag == false)
            {
                touchFlag = true;
                _UI.SetActive(true);
                slider.enabled = true;
                StartCoroutine("LoadData");
            }
        }
        else
        {
            if (Input.touchCount > 0 && touchFlag == false)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchFlag = true;
                    _UI.SetActive(true);
                    slider.enabled = true;
                    StartCoroutine("LoadData");
                }
            }
        }

        if (slider.value == 1f)
        {
            _UI.SetActive(false);
            _Button.SetActive(true);
        }
    }

    IEnumerator LoadData()
    {
        async = SceneManager.LoadSceneAsync("MainScene");
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            rotUI.transform.rotation *= Quaternion.AngleAxis(2.2f, new Vector3(0f, 0f, 1f));

            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;

            yield return null;
        }
    }

    public void tapStart()
    {
        if (slider.value == 1f)
        {
            async.allowSceneActivation = true;
        }
    }
}
