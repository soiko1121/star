using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadFlashing : MonoBehaviour
{
    public float speed;

    private Text text;
    private Image image;
    private float time;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        speed = 1.0f;
        image = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        var color = image.color;
        color.a = GetAlphaColor(color.a);
        image.color = color;

        speed = 1.0f;
    }

    float GetAlphaColor(float color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}