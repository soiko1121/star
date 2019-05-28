using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePlanetController : MonoBehaviour
{
    private GameObject[] littlePlanets;

    public float corpsSpeed;
    public int corpsSplit;
    public float widthSplit;
    public float heightSplit;
    public int delayTime;
    public int circleSprit;
    public int touchDistanse;
    public Vector2 fluctuationDistance;
    public DebugText debugText;
    public InVolumeControl inVolumeControl;

    private int count;
    private float atan;
    private GameObject player;
    private Vector2 distance;
    private Vector3 touchPos;
    
    public int UdlrDelayCount
    {
        get; set;
    }
    public bool TouchMove
    {
        get; set;
    }
    public List<float> RadList
    {
        get; set;
    }
    public int Delay
    {
        get; set;
    }
    public int DelayCount
    {
        get; set;
    }
    public float WidthDistance
    {
        get; set;
    }
    public List<int> TagList
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        DelayCount = 1000;
        count = 0;
        TagList = new List<int>();
        player = GameObject.FindWithTag("Player");
        Delay = delayTime;
        TouchMove = false;
        RadList = new List<float>();
        for (int i = 0; i < 200 * 10; i++)
            RadList.Add(-1);
    }
    private void Update()
    {
        if (((Input.GetMouseButton(0) && !DebugPC.pc) || (Input.GetMouseButton(1) && DebugPC.pc)))
        {
            DelayCount = 0;
        }
        else
        {
            if (count < 10)
                count++;
            else
            {
                if (DelayCount < 1000)
                    DelayCount++;
                count = 0;
            }
        }
        if (((Input.GetMouseButtonDown(0) && !DebugPC.pc) || (Input.GetMouseButtonDown(1) && DebugPC.pc)))
        {
            touchPos = Input.mousePosition;
            RadList = new List<float>();
            for (int i = 0; i < 200 * 10; i++)
                RadList.Add(-1);
        }
        littlePlanets = GameObject.FindGameObjectsWithTag("MiniStar");
        if (((Input.GetMouseButton(0) && !DebugPC.pc) || (Input.GetMouseButton(1) && DebugPC.pc)) && littlePlanets.Length != 0)
        {
            //debugText.text = touchPos.x.ToString() + "\n" + Input.mousePosition.x.ToString() + "\n" + touchPos.y.ToString() + "\n" + Input.mousePosition.y.ToString();
            GetTouch();
            inVolumeControl.touchSwitch = true;
        }
        else if (((Input.GetMouseButtonUp(0) && !DebugPC.pc) || (Input.GetMouseButtonUp(1) && DebugPC.pc)))
        {
            inVolumeControl.touchSwitch = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        littlePlanets = GameObject.FindGameObjectsWithTag("MiniStar");
        for (int i = 0; i < littlePlanets.Length; i++)
        {
            int max = littlePlanets[i].GetComponent<LittlePlanetMove>().Number;
            for (int k = i; k < littlePlanets.Length; k++)
            {
                if (max > littlePlanets[k].GetComponent<LittlePlanetMove>().Number &&
                    littlePlanets[k].GetComponent<LittlePlanetMove>().Number != -1)
                {
                    GameObject gameObject = littlePlanets[i];
                    littlePlanets[i] = littlePlanets[k];
                    littlePlanets[k] = gameObject;
                    max = littlePlanets[k].GetComponent<LittlePlanetMove>().Number;
                }
                if (max == i)
                    break;
            }
        }
        for (int i = 0; i < littlePlanets.Length; i++)
        {
            littlePlanets[i].GetComponent<LittlePlanetMove>().Number = i;
        }
    }
    private void GetTouch()
    {
        distance = new Vector2(Input.mousePosition.x - touchPos.x, Input.mousePosition.y - touchPos.y);
        if (distance.x * distance.x + distance.y * distance.y > touchDistanse * touchDistanse)
        {
            atan = Mathf.Atan2(distance.y, distance.x);
            if (atan < 0)
            {
                atan = 180 * Mathf.Deg2Rad + 180 * Mathf.Deg2Rad - Mathf.Abs(atan);
            }
            if (atan != 0)
            {
                int a = (int)(atan * Mathf.Rad2Deg) / (int)(360f / circleSprit);
                float CircleRad = (a * (360f / circleSprit)) * Mathf.Deg2Rad;
                RadList.Add(CircleRad);
            }
            else
            {
                RadList.Add(0);
            }
        }
        else
        {
            RadList.Add(-1);
        }
        if (RadList.Count > 200 * 10)
        {
            RadList.RemoveAt(0);
        }
    }
}