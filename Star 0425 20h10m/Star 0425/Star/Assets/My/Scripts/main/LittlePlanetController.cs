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

    private int count;
    private GameObject player;
    private Vector3 touchPos;
    public int UdlrDelayCount
    {
        get; set;
    }
    public float CircleRad
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
        CircleRad = 0;
    }
    private void Update()
    {
        if ((Input.GetMouseButton(0) && !DebugPC.pc) || (Input.GetMouseButton(1) && DebugPC.pc))
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
        if ((Input.GetMouseButtonDown(0) && !DebugPC.pc) || (Input.GetMouseButtonDown(1) && DebugPC.pc))
        {
            touchPos = Input.mousePosition;
        }
        if ((Input.GetMouseButton(0) && !DebugPC.pc) || (Input.GetMouseButton(1) && DebugPC.pc))
            GetTouch();
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
        float atan = Mathf.Atan2(Input.mousePosition.y - touchPos.y, Input.mousePosition.x - touchPos.x);
        if (atan < 0)
        {
            atan = 180 * Mathf.Deg2Rad + 180 * Mathf.Deg2Rad - Mathf.Abs(atan);
        }
        if (atan != 0)
        {
            int a = (int)(atan * Mathf.Rad2Deg) / (int)(360f / circleSprit);
            CircleRad = (a * (360f / circleSprit)) * Mathf.Deg2Rad;
        }
        else
        {
            CircleRad = 0;
        }
    }
}