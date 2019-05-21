using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Flashing : MonoBehaviour
{
    public float speed;

    private Text text;
    private Image image;
    private float time;
    private float timer;

    private bool loadFlag;

    [SerializeField]
    GameObject startUI;
    [SerializeField]
    GameObject menuUI;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        speed = 1.0f;
        loadFlag = false;
        image = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        var color = image.color;
        color.a = GetAlphaColor(color.a);
        image.color = color;

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                loadFlag = true;
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    loadFlag = true;
                }
            }
        }

        if (loadFlag)
        {
            speed = 5.0f;          
            timer++;

            if(timer > 40 && color.a >= 0.95)
            {
                speed = 0;
            }
            if (timer > 60)
            {
                Destroy(startUI);
                menuUI.SetActive(true);
                timer = 0;
                speed = 1;
                loadFlag = false;
            }
        }
    }

    float GetAlphaColor(float color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}