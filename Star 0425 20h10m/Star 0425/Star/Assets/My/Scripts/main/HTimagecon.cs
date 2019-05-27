using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HTimagecon : MonoBehaviour
{
    public Sprite[] sprites;
    public float changeTime;

    private Image image;
    private int number;
    private int size;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = sprites[0];
        number = 0;
        count = 0;
        changeTime *= 60;
        size = sprites.Length;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count > changeTime)
        {
            count = 0;
            imgChange();
        }
    }

    void imgChange()
    {
        image.sprite = sprites[number];
        number++;
        if(number >= size)
        {
            number = 0;
        }
    }
}
