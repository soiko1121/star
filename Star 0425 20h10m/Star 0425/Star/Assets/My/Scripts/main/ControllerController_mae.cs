using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerController_mae : MonoBehaviour
{
    public float moveRange;
    public GameObject bigConPre;
    public GameObject smallConPre;
    public Vector3 scale;

    private Vector2 firstPos;
    private Vector2 localPos;
    private Vector3 touchPos;
  　private GameObject lpc;
    private GameObject bigCon;
    private GameObject smallCon;
    private Canvas canvas;
    private RectTransform canvasRect;
    private float moveRad;
    private Vector2 movePos;
    private float a;
    private bool conFlag;

    // Start is called before the first frame update
    void Start()
    {
        lpc = GameObject.Find("LittlePlanetController");
        conFlag = false;
        a = 1;
        moveRange *= scale.x;
    }

    // Update is called once per frame
    void Update()
    {     
        if (((Input.GetMouseButtonDown(0) && !DebugPC.pc) || (Input.GetMouseButtonDown(1) && DebugPC.pc)) && !conFlag)
        {         
            canvas = GetComponent<Canvas>();
            canvasRect = canvas.GetComponent<RectTransform>();

            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (canvasRect, Input.mousePosition,
                 canvas.worldCamera, out localPos);

            bigCon = Instantiate(bigConPre);
            bigCon.transform.SetParent(this.transform);
            bigCon.GetComponent<RectTransform>().localPosition = localPos;
            bigCon.GetComponent<RectTransform>().localScale = scale;
            bigCon.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0, 1);

            smallCon = Instantiate(smallConPre);
            smallCon.transform.SetParent(transform);
            smallCon.GetComponent<RectTransform>().localPosition = localPos;
            smallCon.GetComponent<RectTransform>().localScale = scale;
            smallCon.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0, 1);

            movePos = localPos;
            firstPos = localPos;
            conFlag = true;
        }
        if (conFlag)
        {
            Vector2 mousePos = Input.mousePosition;

            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (canvasRect, mousePos,
                 canvas.worldCamera, out localPos);

            moveRad = Mathf.Atan2(localPos.y - firstPos.y, localPos.x - firstPos.x);
            touchPos = mousePos - firstPos;

            Vector2 dist;
            RectTransformUtility.ScreenPointToLocalPointInRectangle
                (canvasRect, touchPos,
                 canvas.worldCamera, out dist);

            a = dist.magnitude / moveRange;

            if(a > 1f)
            {
                a = 1f;
            }

            movePos.x = a * moveRange * Mathf.Cos(moveRad);
            movePos.y = a * moveRange * Mathf.Sin(moveRad);

            smallCon.GetComponent<RectTransform>().localPosition = firstPos + movePos;

            if ((Input.GetMouseButtonUp(0) && !DebugPC.pc) || (Input.GetMouseButtonUp(1) && DebugPC.pc))
            {
                conFlag = false;
                Destroy(bigCon);
                Destroy(smallCon);
            }
        }
    }
}
