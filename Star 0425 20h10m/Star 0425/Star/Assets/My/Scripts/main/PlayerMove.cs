using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float set2DSpeed;
    public DebugText debugText;
    public TimeGenerator timeGenerator;
    public float defRotaY;
    public float defPosY;
    public Vector2 speedV2;
    public Vector2 gyroLimit;
    public Vector2 limit;
    public Vector2 rotaLimit;
    public Vector2 maxAcceleration;
    public MyAnimator myAnimator;

    private Vector3 gyro, gyroSet, moveVec, velocitySet;

    private Rigidbody playerRB;
    private Vector2 accelerationCount;
    private Vector2 pm;
    private Vector3 target;
    private Vector3 oldpos;
    public List<Vector3> PosList
    {
        get; set;
    }
    public static Vector2 PM
    {
        get; set;
    }
    public enum View
    {
        back, side
    }
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
        oldpos = Vector3.zero;

        accelerationCount = Vector2.zero;
        //acceleration = accelerationSpeed / maxAcceleration;
        pm = new Vector2(1, 1);
        if (PM.x == 0)
        {
            PM = new Vector2(1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeGenerator.GetComponent<TimeGenerator>().cameraMoveNow)
        {
            transform.position = new Vector3(transform.position.x - set2DSpeed, transform.position.y, transform.position.z);
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
            Vector3 v3 = GetGyro();
            transform.rotation = new Quaternion(accelerationCount.y * (rotaLimit.x / maxAcceleration.y) * (-pm.y) + defRotaY, 0, 0, transform.rotation.w);
            myAnimator.X = accelerationCount.x;
            myAnimator.PM = pm.x;
            transform.position = v3;
            oldpos = v3;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                target = GetMousePosition();
                playerRB.velocity = Vector3.zero;
                playerRB.angularVelocity = Vector3.zero;
            }
            Vector3 pos = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
                pos.x += -1;
            if (Input.GetKey(KeyCode.D))
                pos.x += 1;
            if (Input.GetKey(KeyCode.W))
                pos.y += 1;
            if (Input.GetKey(KeyCode.S))
                pos.y += -1;
            pos.x *= PM.x;
            //pos = target - transform.position;
            //pos = pos.normalized * 10f;
            //playerRB.AddForce(pos);
            transform.position += pos * 0.3f;
            myAnimator.X = pos.x;
        }
        PosList.Add(transform.position);
        if (PosList.Count > 200 * 10)
        {
            PosList.RemoveAt(0);
        }
    }
    Vector3 GetGyro()
    {
        Vector3 v3 = transform.position;
        Vector3 gyro = Vector3.zero;
        Vector3 inputGyro = Input.gyro.gravity;
        inputGyro.y *= -1;
        //重力感知
        gyro.x = (20f * inputGyro.x * inputGyro.x + inputGyro.x) / 21f;
        gyro.y = (20f * inputGyro.y * inputGyro.y + inputGyro.y) / 21f;

        if (gyro.x > gyroLimit.x)
            gyro.x = gyroLimit.x;
        if (gyro.y > gyroLimit.y + defPosY)
            gyro.y = gyroLimit.y + defPosY;
        if (inputGyro.y < 0)
            gyro.y = 0;

        if (inputGyro.x > 0)
            pm.x = 1;
        else
            pm.x = -1;
        if (gyro.y > defPosY)
            pm.y = 1;
        else
            pm.y = -1;

        pm *= PM;

        accelerationCount.x = (int)(Mathf.Abs(gyro.x) / (gyroLimit.x / maxAcceleration.x));
        if (gyro.y > defPosY)
            accelerationCount.y = (int)(Mathf.Abs(gyro.y - defPosY) / (gyroLimit.y / maxAcceleration.y));
        else
            accelerationCount.y = (int)maxAcceleration.y - (int)(Mathf.Abs(gyro.y) / (defPosY / maxAcceleration.y));

        if (Mathf.Abs(transform.position.x + accelerationCount.x * (speedV2.x / maxAcceleration.x) * pm.x) < limit.x)
            v3.x = transform.position.x + accelerationCount.x * (speedV2.x / maxAcceleration.x) * pm.x;
        if (Mathf.Abs(transform.position.y + accelerationCount.y * (speedV2.y / maxAcceleration.y) * pm.y) < limit.y)
            v3.y = transform.position.y + accelerationCount.y * (speedV2.y / maxAcceleration.y) * pm.y;
        v3.z = 0;
        return v3;
    }
    Vector3 GetMousePosition()
    {
        Vector3 v3 = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(v3);
        int layerMask = (1 << LayerMask.NameToLayer("Water"));
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            v3 = hit.point;
        }

        return v3;
    }
}