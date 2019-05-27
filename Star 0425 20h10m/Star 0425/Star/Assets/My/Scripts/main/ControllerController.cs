using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerController : MonoBehaviour
{
    public float moveRange;
    public GameObject bigConPre;
    public GameObject smallConPre;
    public Vector3 scale;

    private Vector2 firstPos;
    private Vector2 movePos;
    private Vector3 screensize;
    private Vector3 touchPos;
  　private GameObject lpc;
    private GameObject bigCon;
    private GameObject smallCon;
    private Canvas canvas;
    private RectTransform canvasRect;
    private float moveRad;
    private float a;
    private bool conFlag;

    // Start is called before the first frame update
    void Start()
    {
        lpc = GameObject.Find("LittlePlanetController");
        conFlag = false;
        a = 1;
        moveRange *= scale.x;
        screensize = new Vector3(Screen.width, Screen.height, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {     
        if (Input.GetMouseButtonDown(0) && !conFlag)
        {         
            canvas = GetComponent<Canvas>();
            canvasRect = canvas.GetComponent<RectTransform>();

            Vector2 localPos = Input.mousePosition - screensize / 2;

            bigCon = Instantiate(bigConPre);
            bigCon.transform.SetParent(transform);
            bigCon.GetComponent<RectTransform>().localPosition = localPos;
            bigCon.GetComponent<RectTransform>().localScale = scale;
            bigCon.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0, 1);

            smallCon = Instantiate(smallConPre);
            smallCon.transform.SetParent(transform);
            smallCon.GetComponent<RectTransform>().localPosition = localPos;
            smallCon.GetComponent<RectTransform>().localScale = scale;
            smallCon.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0, 1);

            firstPos = localPos;
            conFlag = true;
        }

        if (conFlag)
        {
            Vector2 mousePos = Input.mousePosition - screensize / 2;

            Vector2 currentPos = mousePos - firstPos;

            moveRad = Mathf.Atan2(currentPos.y, currentPos.x);

            a = currentPos.magnitude / moveRange;

            if(a > 1f)
            {
                a = 1f;
            }

            movePos.x = a * moveRange * Mathf.Cos(moveRad);
            movePos.y = a * moveRange * Mathf.Sin(moveRad);

            smallCon.GetComponent<RectTransform>().localPosition = firstPos + movePos;

            if (Input.GetMouseButtonUp(0))
            {
                conFlag = false;
                Destroy(bigCon);
                Destroy(smallCon);
            }
        }
    }
}
