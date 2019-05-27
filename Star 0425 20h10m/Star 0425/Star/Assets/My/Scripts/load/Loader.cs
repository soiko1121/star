using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    bool onecFlag;

    AsyncOperation async;
    private AudioSource loadSound;
    private bool loadSoundSwitch = true;

    [SerializeField] Slider slider;
    [SerializeField] GameObject _UI;
    [SerializeField] GameObject _Button;
    [SerializeField] Button stButton;
    [SerializeField] Image rotUI;

    public void Start()
    {
        loadSound = gameObject.GetComponent<AudioSource>();
        onecFlag = false;
        slider.enabled = false;
        _UI.SetActive(true);
        _Button.SetActive(false);
        stButton.onClick.AddListener(tapStart);
    }

    public void Update()
    {
        if (onecFlag == false)
        {
            onecFlag = true;
            _UI.SetActive(true);
            slider.enabled = true;
            StartCoroutine("LoadData");
        }
        
        //else
        //{
        //    if (Input.touchCount > 0 && touchFlag == false)
        //    {
        //        Touch touch = Input.GetTouch(0);

        //        if (touch.phase == TouchPhase.Began)
        //        {
        //            touchFlag = true;
        //            _UI.SetActive(true);
        //            slider.enabled = true;
        //            StartCoroutine("LoadData");
        //        }
        //    }
        //}

        if (slider.value == 1f)
        {
            if(loadSoundSwitch)
            {
                loadSound.PlayOneShot(loadSound.clip);
                loadSoundSwitch = false;
            }
            _UI.SetActive(false);
            _Button.SetActive(true);

            if (Input.GetMouseButton(0))
                async.allowSceneActivation = true;
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
            if(Input.GetMouseButton(0))
                async.allowSceneActivation = true;
        }
    }
}
