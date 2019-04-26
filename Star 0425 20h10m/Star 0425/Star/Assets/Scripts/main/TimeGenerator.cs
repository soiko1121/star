using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGenerator : MonoBehaviour
{
    private GameObject mainCamera;
    public GameObject player, target;
    private float timer, setRan, minAngle, maxAngle, rotaTimer, distance;
    private enum View
    {
        back, forward, side
    };
    private View viewSet = View.back, viewOld;
    public float changeTime;
    public bool cameraMoveNow;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        cameraMoveNow = false;
        mainCamera = Camera.main.gameObject;
        rotaTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cameraMoveNow)
        {
            timer += 1 / 60.0f;
            if (timer > changeTime)
            {
                timer = 0;
            }
            if (timer == 0)
            {
                cameraMoveNow = true;
                viewOld = viewSet;

                //setRan = Random.Range(1, 3);
                //viewSet = View.forward;
                switch (viewSet)
                {
                    case View.back:
                        //if (setRan % 2 == 0)
                            viewSet = View.forward;
                        //else
                        //    viewSet = View.side;
                        break;
                    case View.forward:
                        //if (setRan % 2 == 0)
                            viewSet = View.back;
                        //else
                        //    viewSet = View.side;
                        break;
                    //case View.side:
                    //    if (setRan % 2 == 0)
                    //        viewSet = View.forward;
                    //    else
                    //        viewSet = View.back;
                    //    break;
                    default:
                        break;
                }
            }
        }
        else
        {
            //CameraMove();
        }
    }
    private void CameraMove()
    {
        //mainCamera.transform.LookAt(player.transform);
        switch (viewSet)
        {
            case View.back:
                if (viewOld == View.forward)
                {
                    minAngle = 180.0f;
                    maxAngle = 360.0f;
                    distance = 0;
                }
                break;
            case View.forward:
                if (viewOld == View.back)
                {
                    minAngle = 0.0f;
                    maxAngle = 180.0f;
                    distance = 6;
                }
                break;
            case View.side:

                break;
            default:
                break;
        }

        rotaTimer += 1 / 60.0f;
        float angle = Mathf.LerpAngle(minAngle, maxAngle, rotaTimer);
        target.transform.eulerAngles = new Vector3(0, angle, 0);
        target.transform.position = new Vector3(0, 0, distance * rotaTimer);

        if (rotaTimer >= 1f)
        {
            rotaTimer = 0;
            cameraMoveNow = false;
        }
    }
}
