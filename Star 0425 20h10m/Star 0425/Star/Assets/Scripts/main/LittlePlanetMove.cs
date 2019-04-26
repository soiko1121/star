using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePlanetMove : MonoBehaviour
{
    public Vector3 target;
    public float speed;
    public bool up;
    public bool left;

    public float corpsSpeed;
    public int corpsSplitX;
    public int corpsSplitY;
    public float widthSplit;
    public float heightSplit;


    private GameObject player;
    private Rigidbody littlePlanetRB;
    private bool hit, blockDel = false;
    private int count;

    private GameObject gameGenerator;
    public int Number
    {
        get; set;
    }
    void Start()
    {
        hit = false;
        Number = -1;
        count = 0;
        player = GameObject.FindWithTag("Player");
        littlePlanetRB = GetComponent<Rigidbody>();
        littlePlanetRB.AddForce((transform.position - target) * 300f);//目的地と反対に飛ばす

        gameGenerator = GameObject.Find("GameGenerator");
        gameGenerator.GetComponent<GameGenerator>().star++;
    }

    void Update()
    {
        if (!gameGenerator.GetComponent<TimeGenerator>().cameraMoveNow)
        {
            ColorChange();
            if (!hit)
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
        }
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
        littlePlanetRB.velocity = Vector3.zero;
        littlePlanetRB.angularVelocity = Vector3.zero;
        Vector3 target;
        int index = player.GetComponent<PlayerMove>().PosList.Count - 1;

        target.x = player.GetComponent<PlayerMove>().PosList[index - (Number / (corpsSplitX * corpsSplitY))].x -
            (corpsSplitX - 1) * heightSplit / 2f + heightSplit * (Number % corpsSplitX);

        target.y = player.GetComponent<PlayerMove>().PosList[index - (Number / (corpsSplitX * corpsSplitY))].y -
            (corpsSplitY - 1) * heightSplit / 2f + heightSplit * (Number / corpsSplitY % corpsSplitY);

        target.z = player.GetComponent<PlayerMove>().PosList[index - (Number / (corpsSplitX * corpsSplitY))].z -
            1 - widthSplit * (Number / (corpsSplitX * corpsSplitY));

        Vector3 move = target - transform.position;
        littlePlanetRB.AddForce(move * corpsSpeed);
    }
    private void ColorChange()
    {
        if (Number != -1)
        {
            switch (Number % 5)
            {
                case 0:
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 2:
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case 3:
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 4:
                    gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Group")
        {
            hit = true;
            littlePlanetRB.velocity = Vector3.zero;
            littlePlanetRB.angularVelocity = Vector3.zero;
        }

        if (other.gameObject.tag == "DangerObject")
        {
            Destroy(gameObject);
            if (!blockDel)
            {
                gameGenerator.GetComponent<GameGenerator>().star--;
                blockDel = true;
            }

        }
    }
}