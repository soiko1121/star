using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nameCon : MonoBehaviour
{
    public Sprite[] sprites;

    private Image img;
    private RectTransform imgRect;

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        imgRect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        img.sprite = sprites[SelectStage.StageSelectNumber - 1];
        imgRect.sizeDelta = new Vector2(sprites[SelectStage.StageSelectNumber - 1].bounds.size.x * 100, 75f);
        
    }
}
