using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePlanetMove : MonoBehaviour
{
    public Vector3 target;
    public float speed;
    public bool up;
    public bool left;
    private GameObject littlePlanetController;
    private LittlePlanetController controller;

    private GameObject player;
    private Rigidbody littlePlanetRB;
    private int count, moveCount;
    private float distance;
    private Vector3 oldPos;
    private GameObject gameGenerator;
    private int indexCount;
    public bool Hit
    {
        get; set;
    }
    public int Number
    {
        get; set;
    }
    void Start()
    {
        Hit = false;
        Number = -1;
        count = 0;
        moveCount = 120;
        oldPos = Vector3.zero;
        player = GameObject.FindWithTag("Player");
        littlePlanetRB = GetComponent<Rigidbody>();
        littlePlanetRB.AddForce((transform.position - target) * 300f);//目的地と反対に飛ばす
        indexCount = 200 * 10 - 1;

        gameGenerator = GameObject.Find("GameGenerator");
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (!Hit)
        {
            if (count < 120)
            {
                count += 1;
            }
            else
            {
                PlayerFollow();
            }
        }
        else
        {
            Corps();
        }
        transform.Rotate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)));
    }
    private void PlayerFollow()
    {
        littlePlanetRB.velocity = Vector3.zero;
        littlePlanetRB.angularVelocity = Vector3.zero;
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 2);
        Vector3 move = target - transform.position;
        littlePlanetRB.AddForce(move * speed);
        if (transform.position.z < player.transform.position.z - 2)
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 2);
    }
    private void Corps()
    {
        littlePlanetController = GameObject.FindWithTag("LittlePlanetController");
        controller = littlePlanetController.GetComponent<LittlePlanetController>();
        littlePlanetRB.velocity = Vector3.zero;
        littlePlanetRB.angularVelocity = Vector3.zero;
        Vector3 target;
        int index = player.GetComponent<PlayerMove>().PosList.Count - 1;
        int corpsIndex = Number / controller.GetComponent<LittlePlanetController>().corpsSplit;

        if (index < corpsIndex * controller.Delay)
            corpsIndex = index / controller.Delay;


        if (moveCount != 120)
        {
            moveCount++;
        }
        else
        {
            distance = Random.Range(controller.GetComponent<LittlePlanetController>().heightSplit, 1f + 0.01f * (Number / controller.corpsSplit));
            moveCount = 0;
        }
        if (((Input.GetMouseButton(0) && !DebugPC.pc) || (Input.GetMouseButton(1) && DebugPC.pc)))
        {
            Vector3 fluctuation = Vector3.zero;
            int delay = 4;
            if (controller.RadList[200 * 10 - 1 - corpsIndex * (controller.Delay / delay)] != -1)
            {
                fluctuation.x = (Number / controller.corpsSplit * controller.fluctuationDistance.x) * Mathf.Cos(controller.RadList[200 * 10 - 1 - corpsIndex * (controller.Delay / delay)]);
                fluctuation.y = (Number / controller.corpsSplit * controller.fluctuationDistance.y) * Mathf.Sin(controller.RadList[200 * 10 - 1 - corpsIndex * (controller.Delay / delay)]);
                if (Goal.ClearFlag)
                    fluctuation.x *= -1;

            }

            target.x = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * (controller.Delay / 3)].x + fluctuation.x +
                distance * Mathf.Cos(((360f / controller.corpsSplit) * (Number % controller.corpsSplit)) * Mathf.Deg2Rad);

            target.y = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * (controller.Delay / 3)].y + fluctuation.y +
                distance * Mathf.Sin(((360f / controller.corpsSplit) * (Number % controller.corpsSplit)) * Mathf.Deg2Rad);

            target.z = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * (controller.Delay / 3)].z - controller.widthSplit / 5 * corpsIndex;
            oldPos = target;
            indexCount = 200 * 10 - 1 - corpsIndex * (controller.Delay / delay);
        }
        else if (indexCount < 200 * 10 - 1)
        {
            Vector3 fluctuation = Vector3.zero;
            int delay = 4;
            if (controller.RadList[indexCount] != -1)
            {
                fluctuation.x = (Number / controller.corpsSplit * controller.fluctuationDistance.x) * Mathf.Cos(controller.RadList[indexCount]);
                fluctuation.y = (Number / controller.corpsSplit * controller.fluctuationDistance.y) * Mathf.Sin(controller.RadList[indexCount]);
                if (Goal.ClearFlag)
                    fluctuation.x *= -1;
            }

            target.x = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * (controller.Delay / 3)].x + fluctuation.x +
                distance * Mathf.Cos(((360f / controller.corpsSplit) * (Number % controller.corpsSplit)) * Mathf.Deg2Rad);

            target.y = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * (controller.Delay / 3)].y + fluctuation.y +
                distance * Mathf.Sin(((360f / controller.corpsSplit) * (Number % controller.corpsSplit)) * Mathf.Deg2Rad);

            target.z = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * (controller.Delay / 3)].z - controller.widthSplit / 5 * corpsIndex;
            oldPos = target;
            indexCount++;
        }
        else if (corpsIndex < controller.DelayCount)
        {
            target.x = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * controller.Delay].x +
                distance * Mathf.Cos(((360f / controller.corpsSplit) * (Number % controller.corpsSplit)) * Mathf.Deg2Rad);

            target.y = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * controller.Delay].y +
                distance * Mathf.Sin(((360f / controller.corpsSplit) * (Number % controller.corpsSplit)) * Mathf.Deg2Rad);

            target.z = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * controller.Delay].z - controller.widthSplit * corpsIndex;
        }
        else
        {
            target.x = oldPos.x + distance * Mathf.Cos(((360f / controller.corpsSplit) * (Number % controller.corpsSplit)) * Mathf.Deg2Rad);

            target.y = oldPos.y + distance * Mathf.Sin(((360f / controller.corpsSplit) * (Number % controller.corpsSplit)) * Mathf.Deg2Rad);

            target.z = player.GetComponent<PlayerMove>().PosList[index - corpsIndex * controller.Delay].z - controller.widthSplit * corpsIndex;
        }

        Vector3 move = target - transform.position;
        //littlePlanetRB.AddForce(move * controller.corpsSpeed);
        transform.position += move * controller.corpsSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Group")
        {
            Hit = true;
            littlePlanetRB.velocity = Vector3.zero;
            littlePlanetRB.angularVelocity = Vector3.zero;
        }

        if (other.gameObject.tag == "DangerObject" && Hit)
        {
            Destroy(gameObject);
        }
    }
}