using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectController : MonoBehaviour
{
    public GameObject[] 
        mask,
        stageNum;
    public Sprite[] stageNumImage;
    public int delaycount;
    public bool loadFlag;
    private bool 
        setStage1,
        onece = false;
    private GameObject titleBGM;
    [SerializeField]
    private string[] nameSpace;
     // Start is called before the first frame update
    void Start()
    {
        setStage1 = true;
        delaycount = 0;
        loadFlag = false;
        titleBGM = GameObject.Find("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        switch (SelectStage.StageSelectNumber)
        {
            case (int)SelectStage.Stage.Easy:
                stageNum[0].GetComponent<Image>().sprite = stageNumImage[0];
                stageNum[1].GetComponent<Image>().sprite = stageNumImage[1];
                break;
            case (int)SelectStage.Stage.Normal:
                stageNum[0].GetComponent<Image>().sprite = stageNumImage[2];
                stageNum[1].GetComponent<Image>().sprite = stageNumImage[3];
                break;
            case (int)SelectStage.Stage.Hard:
                stageNum[0].GetComponent<Image>().sprite = stageNumImage[4];
                stageNum[1].GetComponent<Image>().sprite = stageNumImage[5];
                break;
            default:
                break;
        }
        if (setStage1)
        {
            mask[0].SetActive(false);
            mask[1].SetActive(true);
        }
        else
        {
            mask[0].SetActive(true);
            mask[1].SetActive(false);
        }
        if (delaycount > 50)
        {
            titleBGM.GetComponent<ButtonDontDestroy>().DestroyThisObject();
            SceneManager.LoadScene("LoadScene");
        }
    }
    public void Stage1OnClick()
    {
        if (!setStage1)
            setStage1 = true;
        else
        {
            if (!onece)
            {
                loadFlag = true;
                onece = true;
            }
        }
    }
    public void Stage2OnClick()
    {
        if (setStage1)
            setStage1 = false;
        else
        {
            if (!onece)
            {
                loadFlag = true;
                onece = true;
                SelectStage.StageSelectNumber++;
            }
        }
    }
}
