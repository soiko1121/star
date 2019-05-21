using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{
    public Button[] buttons;

    public float centerX;
    public float centerY;
    public float delta;

    float ax = 550f;
    float by = 150f;
    float posX = 0f;
    float posY = 0f;
    float rad = 90f;

    bool rightFlag = false;
    bool leftFlag = false;
    bool once = false;

    HowtoController flick = new HowtoController();

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < buttons.Length; i++)
        {
            posX = ax * Mathf.Cos(Mathf.PI / 180 * (rad + (120 * i))) + centerX;
            posY = by * Mathf.Sin(Mathf.PI / 180 * (rad + (120 * i))) + centerY;

            buttons[i].GetComponent<RectTransform>().localPosition = new Vector3(posX, posY, 0);
            buttons[i].GetComponent<RectTransform>().localScale = new Vector3((posY / by) + 2f, (posY / by) + 2f, (posY / by) + 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rightFlag)
        {
            circleMove(delta);

            if ((rad - 90) % 120 == 0)
            {
                rightFlag = false;
                flick.flickDirection = (int)HowtoController.direction.none;

                SelectStage.StageSelectNumber++;
                if (SelectStage.maxStageNumber < SelectStage.StageSelectNumber)
                {
                    SelectStage.StageSelectNumber = SelectStage.minStageNumber;
                }
            }
        }

        if (leftFlag)
        {
            circleMove(-1*delta);

            if ((rad - 90) % 120 == 0)
            {              
                leftFlag = false;
                flick.flickDirection = (int)HowtoController.direction.none;

                SelectStage.StageSelectNumber--;
                if (SelectStage.minStageNumber > SelectStage.StageSelectNumber)
                {
                    SelectStage.StageSelectNumber = SelectStage.maxStageNumber;
                }
            }
        }

        flick.Flicker();
        if (flick.flickDirection == (int)HowtoController.direction.right)
        {
            rightFlag = true;
        }
        if (flick.flickDirection == (int)HowtoController.direction.left)
        {
            leftFlag = true;
        }
    }

    void circleMove(float delta)
    {
        rad -= delta;
        for (var i = 0; i < buttons.Length; i++)
        {
            posX = ax * Mathf.Cos(Mathf.PI / 180 * (rad + (120 * i))) + centerX;
            posY = by * Mathf.Sin(Mathf.PI / 180 * (rad + (120 * i))) + centerY;

            buttons[i].GetComponent<RectTransform>().localPosition = new Vector3(posX, posY, 0);
            buttons[i].GetComponent<RectTransform>().localScale = new Vector3((posY / by) + 2f, 
                                                                              (posY / by) + 2f, 
                                                                              (posY / by) + 2f);
        }
    }

    public void moveRight()
    {
        rightFlag = true;
    }

    public void moveLeft()
    {
        leftFlag = true;
    }
}
