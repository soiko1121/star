using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultRank : MonoBehaviour
{
    public Sprite[] rank = new Sprite[7];
    public GameObject rankViwe;
    private RectTransform size;
    private Vector2 sizeV2;
    private int setRank;
    private float addTimer;
    private bool rankShowNow;
    // Start is called before the first frame update
    void Start()
    {
        size = rankViwe.GetComponent<RectTransform>();
        rankShowNow = false;
        setRank = 0;
        addTimer = 0;
        sizeV2 = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        float point = Vector2.Lerp(new Vector2(0, 0), new Vector2(425, 0), addTimer).x;
        sizeV2 = new Vector2(point, point);
        addTimer += Time.deltaTime;

        size.sizeDelta = sizeV2;
    }
    public void ShowRank(int score)
    {
        rankShowNow = true;
        switch(SelectStage.StageSelectNumber)
        {
            case (int)SelectStage.Stage.Easy:
                if (score < 1000)
                    setRank = 0;
                else if (score < 2000)
                    setRank = 1;
                break;
            case (int)SelectStage.Stage.Easy + 1:
                break;
            case (int)SelectStage.Stage.Normal:
                break;
            case (int)SelectStage.Stage.Normal + 1:
                break;
            case (int)SelectStage.Stage.Hard:
                break;
            case (int)SelectStage.Stage.Hard + 1:
                break;
        }
        rankViwe.GetComponent<Image>().sprite = rank[setRank];
    }
}
