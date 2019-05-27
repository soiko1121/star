using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageSelector : MonoBehaviour
{
    public Button[] buttons;
    public GameObject canvas;
    public float centerX;
    public float centerY;
    public float delta;

    float ax = 550f;
    float by = 150f;
    float posX = 0f;
    float posY = 0f;
    float rad = 90f;
    float shakeRad = 0;

    bool rightFlag = false;
    bool leftFlag = false;
    bool once = false;

    HowtoController flick;

    // Start is called before the first frame update
    void Start()
    {
        flick = new HowtoController();
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
        if (canvas.activeSelf)
        {
            flick.Flicker();
            return;
        }
        shake(shakeRad);
        shakeRad += 1f ;

        if (rightFlag)
        {
            circleMove(delta);

            if ((rad - 90) % 120 == 0)
            {
                rightFlag = false;
                flick.flickDirection = (int)HowtoController.direction.none;

                SelectStage.StageSelectNumber += 2;
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

                SelectStage.StageSelectNumber -= 2;
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

    void shake(float rad)
    {
        float y = 6 * Mathf.Sin(Mathf.PI/180 * rad);
        buttons[SelectStage.StageSelectNumber - 1].GetComponent<RectTransform>().localPosition = new Vector3(0, y, 0);
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
