using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 gyro, gyroSet, moveVec, velocitySet;
    private Rigidbody playerRB;
    public float speed, slowdown, set2DSpeed;
    public DebugText debugText;
    public TimeGenerator timeGenerator;
    public float ySpeed2D;
    public float gyroLimit;
    public Vector2 limit;
    public Vector2 rotaLimit;

    //public Vector2 accelerationSpeed;
    public Vector2 maxAcceleration;
    private Vector2 accelerationCount;
    //private Vector2 acceleration;
    private Vector2 pm;
    private Vector3 target;
    private Vector2 speedV2;
    private Vector3 oldpos;
    public List<Vector3> PosList
    {
        get; set;
    }
    public enum View
    {
        back, side
    };
    public View viewSet = View.back;
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
        speedV2 = new Vector2(speed, speed);
        oldpos = Vector3.zero;

        accelerationCount = Vector2.zero;
        //acceleration = accelerationSpeed / maxAcceleration;
        pm = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeGenerator.GetComponent<TimeGenerator>().cameraMoveNow)
        {
            if (viewSet == View.side)
            {
                transform.position = new Vector3(transform.position.x - set2DSpeed, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - set2DSpeed);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DebugPC.pc = true;
        }
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (!DebugPC.pc)
        {
            Vector3 v3 = transform.position;
            //重力感知
            gyro.x = Mathf.Clamp(Input.gyro.gravity.x * 2.0f, -gyroLimit, gyroLimit);
            gyro.y = Mathf.Clamp(((Input.gyro.gravity.z + 0.7f) * 2.0f), -gyroLimit, gyroLimit);
            //debugText.GetComponent<DebugText>().text = gyro.x.ToString() + ":::::::" + gyro.y.ToString();
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
            if (gyro.y < 0)
                gyro.y *= 1.6f;
            accelerationCount.x = (Mathf.Abs(gyro.x) / (int)(gyroLimit / maxAcceleration.x));
            accelerationCount.y = (Mathf.Abs(gyro.y) / (int)(gyroLimit / maxAcceleration.y));
            if (viewSet == View.back)
            {
                if (Mathf.Abs(transform.position.x + accelerationCount.x * 0.5f * (gyroLimit / maxAcceleration.x) * speedV2.x * pm.x) < limit.x)
                    v3.x = transform.position.x + accelerationCount.x * 0.5f * (gyroLimit / maxAcceleration.x) * speedV2.x * pm.x;
                else
                    v3.x = transform.position.x;
                if (Mathf.Abs(transform.position.y + accelerationCount.y * 0.5f * (gyroLimit / maxAcceleration.y) * speedV2.y * pm.y) < limit.y)
                    v3.y = transform.position.y + accelerationCount.y * 0.5f * (gyroLimit / maxAcceleration.y) * speedV2.y * pm.y;
                else
                    v3.y = transform.position.y;
                v3.z = 0;
                //transform.LookAt(new Vector3(v3.x * 1.1f, v3.y - 1, 2));
            }
            //else
            //{
            //    v3 = new Vector3(
            //        0,
            //        transform.position.y + accelerationCount.y * (gyroLimit / maxAcceleration.y) * speedV2.y * ySpeed2D * pm.y,
            //        transform.position.z + accelerationCount.x * (gyroLimit / maxAcceleration.x) * speedV2.x * pm.x);
            //}
            //if (v3.z < -2)
            //{
            //    v3.z = -2;
            //}
            //if (v3.z > 2)
            //{
            //    v3.z = 2;
            //}
            transform.position = v3;
            //playerRB.AddForce(v3 - transform.position);
            oldpos = v3;
            MyAnimator.X = gyro.x;
            //debugText.GetComponent<DebugText>().debugVec3 = gyro;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                target = GetMousePosition();
                playerRB.velocity = Vector3.zero;
                playerRB.angularVelocity = Vector3.zero;
            }
            Vector3 pos = target - transform.position;
            pos = pos.normalized * 10f;
            playerRB.AddForce(pos);
            MyAnimator.X = pos.x;
        }
        PosList.Add(transform.position);
        if (PosList.Count > 200 * 10)
        {
            PosList.RemoveAt(0);
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
