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

    private int count;
    private GameObject player;
    private Vector3 touchPos;
    public enum UDLR { up, down, left, right, no }
    public UDLR[] Udlr
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
        Udlr = new UDLR[2] { UDLR.no, UDLR.no };
        Delay = delayTime;
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
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
            Udlr[0] = UDLR.no;
            Udlr[1] = UDLR.no;
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
        if (Input.mousePosition.x - touchPos.x > 200)
            Udlr[0] = UDLR.right;
        else if (Input.mousePosition.x - touchPos.x < -200)
            Udlr[0] = UDLR.left;
        else
            Udlr[0] = UDLR.no;

        if (Input.mousePosition.y - touchPos.y > 200)
            Udlr[1] = UDLR.up;
        else if (Input.mousePosition.y - touchPos.y < -200)
            Udlr[1] = UDLR.down;
        else
            Udlr[1] = UDLR.no;
    }
}
