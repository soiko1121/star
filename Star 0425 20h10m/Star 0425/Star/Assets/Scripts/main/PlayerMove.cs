using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 gyro, gyroSet, moveVec, velocitySet;
    private Rigidbody playerRB;
    public float speed, slowdown;
    public DebugText debugText;
    private int count;
    public TimeGenerator timeGenerator;

    //public Vector2 accelerationSpeed;
    public Vector2 maxAcceleration;
    private Vector2 accelerationCount;
    //private Vector2 acceleration;
    private Vector2 pm;
    private Vector3 target;
    public List<Vector3> PosList
    {
        get; set;
    }
    // Start is called before the first frame update
    void Start()
    {
        //ジャイロセンサーOn！
        Input.gyro.enabled = true;
        gyroSet = Input.gyro.gravity;
        playerRB = GetComponent<Rigidbody>();
        moveVec = Vector3.zero;
        PosList = new List<Vector3>();
        target = Vector3.zero;
        gyro = Vector3.zero;
        gyroSet = Vector3.zero;

        accelerationCount = Vector2.zero;
        //acceleration = accelerationSpeed / maxAcceleration;
        pm = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeGenerator.GetComponent<TimeGenerator>().cameraMoveNow || true)
        {
            if (Mathf.Clamp(Input.gyro.gravity.z * 2.0f, -9.8f, 9.8f) != 0 || -Mathf.Clamp(((Input.gyro.gravity.y + 0.4f) * 2.0f), -9.8f, 9.8f) != 0)
            {
                Vector3 v3 = Vector3.zero;
                //重力感知
                gyro.x = Mathf.Clamp(Input.gyro.gravity.x * 2.0f, -9.8f, 9.8f);
                gyro.y = -Mathf.Clamp(((Input.gyro.gravity.y + 0.4f) * 2.0f), -9.8f, 9.8f);
                velocitySet = playerRB.velocity;
                if (gyro.x > 0)
                {
                    pm.x = 1;
                }
                else
                {
                    pm.x = -1;
                }
                if (gyro.y > 0)
                {
                    pm.y = 1;
                }
                else
                {
                    pm.y = -1;
                }
                if (moveVec.x < 0 && gyro.x > 0 || moveVec.x > 0 && gyro.x < 0)
                {
                    velocitySet.x /= slowdown;
                    velocitySet.x = 0;
                }
                if (moveVec.y < 0 && gyro.y > 0 || moveVec.y > 0 && gyro.y < 0)
                {
                    velocitySet.y /= slowdown;
                    velocitySet.y = 0;
                }
                accelerationCount.x = (Mathf.Abs(gyro.x) / (9.8f / maxAcceleration.x));
                accelerationCount.y = (Mathf.Abs(gyro.y) / (9.8f / maxAcceleration.y));
                playerRB.velocity = velocitySet;
                //playerRB.AddForce(gyro * speed);
                v3.x = accelerationCount.x * (9.8f / maxAcceleration.x) * speed;
                v3.y = accelerationCount.y * (9.8f / maxAcceleration.y) * speed;
                transform.position += v3 *= pm;
                v3 = transform.position;
                if (transform.position.x < -16)
                {
                    v3.x = -16;
                }
                if (transform.position.x > 16)
                {
                    v3.x = 16;
                }
                if (transform.position.y < -9)
                {
                    v3.y = -9;
                }
                if (transform.position.y > 9)
                {
                    v3.y = 9;
                }
                transform.position = v3;
                moveVec = gyro;
                //debugText.GetComponent<DebugText>().debugVec3 = gyro;
            }
            else
            {
                Debug.Log("aaa");
                if (Input.GetMouseButton(0))
                {
                    target = GetMousePosition();
                    playerRB.velocity = Vector3.zero;
                    playerRB.angularVelocity = Vector3.zero;
                }
                Vector3 pos = target - transform.position;
                pos = pos.normalized * 10f;
                playerRB.AddForce(pos);
            }
            if (count != 10)
            {
                count++;
            }
            else
            {
                PosList.Add(transform.position);
                if (PosList.Count > 200)
                {
                    PosList.RemoveAt(0);
                }
                count = 0;
            }
        }
    }
    Vector3 GetMousePosition()
    {
        Vector3 v3 = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(v3);
        RaycastHit hit;
        int layerMask = (1 << LayerMask.NameToLayer("Water"));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            v3 = hit.point;
        }

        return v3;
    }
}
