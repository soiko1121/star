using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultRank : MonoBehaviour
{
    public Sprite[] rank = new Sprite[7];
    //Inspectorに複数データを表示するためのクラス
    [System.SerializableAttribute]
    public class ValueList
    {
        public List<int> List = new List<int>();

        public ValueList(List<int> list)
        {
            List = list;
        }
    }
    //Inspectorに表示される
    [SerializeField]
    private List<ValueList> valueListList = new List<ValueList>();

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
        if (rankShowNow)
        {
            float point = Vector2.Lerp(new Vector2(0, 0), new Vector2(425, 0), addTimer).x;
            sizeV2 = new Vector2(point, point);
            addTimer += Time.deltaTime;
        }
        size.sizeDelta = sizeV2;
    }
    public void ShowRank(int score)
    {
        rankShowNow = true;
        switch(SelectStage.StageSelectNumber)
        {
            case (int)SelectStage.Stage.Easy:
                if (score < valueListList[(int)SelectStage.Stage.Easy - 1].List[0])
                    setRank = 0;
                else if (score < valueListList[(int)SelectStage.Stage.Easy - 1].List[1])
                    setRank = 1;
                else if (score < valueListList[(int)SelectStage.Stage.Easy - 1].List[2])
                    setRank = 2;
                else if (score < valueListList[(int)SelectStage.Stage.Easy - 1].List[3])
                    setRank = 3;
                else if (score < valueListList[(int)SelectStage.Stage.Easy - 1].List[4])
                    setRank = 4;
                else if (score < valueListList[(int)SelectStage.Stage.Easy - 1].List[5])
                    setRank = 5;
                else
                    setRank = 6;
                break;
            case (int)SelectStage.Stage.Easy + 1:
                if (score < valueListList[(int)SelectStage.Stage.Easy].List[0])
                    setRank = 0;
                else if (score < valueListList[(int)SelectStage.Stage.Easy].List[1])
                    setRank = 1;
                else if (score < valueListList[(int)SelectStage.Stage.Easy].List[2])
                    setRank = 2;
                else if (score < valueListList[(int)SelectStage.Stage.Easy].List[3])
                    setRank = 3;
                else if (score < valueListList[(int)SelectStage.Stage.Easy].List[4])
                    setRank = 4;
                else if (score < valueListList[(int)SelectStage.Stage.Easy].List[5])
                    setRank = 5;
                else
                    setRank = 6;
                break;
            case (int)SelectStage.Stage.Normal:
                if (score < valueListList[(int)SelectStage.Stage.Normal - 1].List[0])
                    setRank = 0;
                else if (score < valueListList[(int)SelectStage.Stage.Normal - 1].List[1])
                    setRank = 1;
                else if (score < valueListList[(int)SelectStage.Stage.Normal - 1].List[2])
                    setRank = 2;
                else if (score < valueListList[(int)SelectStage.Stage.Normal - 1].List[3])
                    setRank = 3;
                else if (score < valueListList[(int)SelectStage.Stage.Normal - 1].List[4])
                    setRank = 4;
                else if (score < valueListList[(int)SelectStage.Stage.Normal - 1].List[5])
                    setRank = 5;
                else
                    setRank = 6;
                break;
            case (int)SelectStage.Stage.Normal + 1:
                if (score < valueListList[(int)SelectStage.Stage.Normal].List[0])
                    setRank = 0;
                else if (score < valueListList[(int)SelectStage.Stage.Normal].List[1])
                    setRank = 1;
                else if (score < valueListList[(int)SelectStage.Stage.Normal].List[2])
                    setRank = 2;
                else if (score < valueListList[(int)SelectStage.Stage.Normal].List[3])
                    setRank = 3;
                else if (score < valueListList[(int)SelectStage.Stage.Normal].List[4])
                    setRank = 4;
                else if (score < valueListList[(int)SelectStage.Stage.Normal].List[5])
                    setRank = 5;
                else
                    setRank = 6;
                break;
            case (int)SelectStage.Stage.Hard:
                if (score < valueListList[(int)SelectStage.Stage.Hard - 1].List[0])
                    setRank = 0;
                else if (score < valueListList[(int)SelectStage.Stage.Hard - 1].List[1])
                    setRank = 1;
                else if (score < valueListList[(int)SelectStage.Stage.Hard - 1].List[2])
                    setRank = 2;
                else if (score < valueListList[(int)SelectStage.Stage.Hard - 1].List[3])
                    setRank = 3;
                else if (score < valueListList[(int)SelectStage.Stage.Hard - 1].List[4])
                    setRank = 4;
                else if (score < valueListList[(int)SelectStage.Stage.Hard - 1].List[5])
                    setRank = 5;
                else
                    setRank = 6;
                break;
            case (int)SelectStage.Stage.Hard + 1:
                if (score < valueListList[(int)SelectStage.Stage.Hard].List[0])
                    setRank = 0;
                else if (score < valueListList[(int)SelectStage.Stage.Hard].List[1])
                    setRank = 1;
                else if (score < valueListList[(int)SelectStage.Stage.Hard].List[2])
                    setRank = 2;
                else if (score < valueListList[(int)SelectStage.Stage.Hard].List[3])
                    setRank = 3;
                else if (score < valueListList[(int)SelectStage.Stage.Hard].List[4])
                    setRank = 4;
                else if (score < valueListList[(int)SelectStage.Stage.Hard].List[5])
                    setRank = 5;
                else
                    setRank = 6;
                break;
            default:
                break;
        }
        if (!TotalScore.IsClear)
            setRank = 0;
        rankViwe.GetComponent<Image>().sprite = rank[setRank];
    }
}
