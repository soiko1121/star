using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 gyro, gyroSet, moveVec, velocitySet;
    private Rigidbody playerRB;
    public float slowdown, set2DSpeed;
    public DebugText debugText;
    public TimeGenerator timeGenerator;
    public float ySpeed2D;
    public float defY;
    public Vector2 speedV2;
    public Vector2 gyroLimit;
    public Vector2 limit;
    public Vector2 rotaLimit;
    public MyAnimator myAnimator;

    //public Vector2 accelerationSpeed;
    public Vector2 maxAcceleration;
    private Vector2 accelerationCount;
    //private Vector2 acceleration;
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
            Vector3 v3 = GetGyro();
            ////重力感知
            //gyro.x = Mathf.Clamp(Input.gyro.gravity.x * 2.0f, -gyroLimit, gyroLimit);
            //gyro.y = Mathf.Clamp(((Input.gyro.gravity.z + 0.7f) * 2.0f), -gyroLimit, gyroLimit);

            //float a = (20f * Input.gyro.gravity.y * Input.gyro.gravity.y + Input.gyro.gravity.y) / 21f;
            //float b = (20f * Input.gyro.gravity.x * Input.gyro.gravity.x + Input.gyro.gravity.x) / 21f;
            //debugText.GetComponent<DebugText>().text = Input.gyro.gravity.x.ToString() + "\n" + a.ToString() + "\n" + b.ToString();
            //if (gyro.x > 0)
            //{
            //    pm.x = 1;
            //}
            //else
            //{
            //    pm.x = -1;
            //}
            //if (gyro.y > 0)
            //{
            //    pm.y = 1;
            //}
            //else
            //{
            //    pm.y = -1;
            //}
            //pm *= PM;
            //if (gyro.y < 0)
            //    gyro.y *= 1.6f;
            //accelerationCount.x = (Mathf.Abs(gyro.x) / (int)(gyroLimit / maxAcceleration.x));
            //accelerationCount.y = (Mathf.Abs(gyro.y) / (int)(gyroLimit / maxAcceleration.y));
            //if (viewSet == View.back)
            //{
            //    if (Mathf.Abs(transform.position.x + accelerationCount.x * 0.5f * (gyroLimit / maxAcceleration.x) * speedV2.x * pm.x) < limit.x)
            //        v3.x = transform.position.x + accelerationCount.x * 0.5f * (gyroLimit / maxAcceleration.x) * speedV2.x * pm.x;
            //    else
            //        v3.x = transform.position.x;
            //    if (Mathf.Abs(transform.position.y + accelerationCount.y * 0.5f * (gyroLimit / maxAcceleration.y) * speedV2.y * pm.y) < limit.y)
            //        v3.y = transform.position.y + accelerationCount.y * 0.5f * (gyroLimit / maxAcceleration.y) * speedV2.y * pm.y;
            //    else
            //        v3.y = transform.position.y;
            //    v3.z = 0;
            //    //if(accelerationCount.y * 0.5f * (gyroLimit / maxAcceleration.y) * speedV2.y * pm.y + 0.4f > 0.7f)
            //    //    transform.rotation = new Quaternion(-0.7f, 0, 0, transform.rotation.w);
            //    //else
            //    //transform.rotation = new Quaternion(-(accelerationCount.y * 0.5f * (gyroLimit / maxAcceleration.y) * speedV2.y * pm.y) + 0.4f, 0, 0, transform.rotation.w);
            //}
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
            myAnimator.X = v3.x - transform.position.x;
            transform.position = v3;
            //playerRB.AddForce(v3 - transform.position);
            oldpos = v3;
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
            Vector3 pos = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
                pos.x += -1;
            if (Input.GetKey(KeyCode.D))
                pos.x += 1;
            if (Input.GetKey(KeyCode.W))
                pos.y += 1;
            if (Input.GetKey(KeyCode.S))
                pos.y += -1;
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
        //重力感知
        gyro.x = (20f * inputGyro.x * inputGyro.x + inputGyro.x) / 21f;
        gyro.y = (20f * inputGyro.y * inputGyro.y + inputGyro.y) / 21f;

        if (gyro.x > gyroLimit.x)
            gyro.x = gyroLimit.x;
        //if (gyro.y > gyroLimit.y + defY)
        //    gyro.y = gyroLimit.y + defY;
        //if (inputGyro.y < 0)
        //    gyro.y = 0;
        //debugText.GetComponent<DebugText>().text = gyro.x.ToString() + "\n" + gyro.y.ToString();

        if (inputGyro.x > 0)
            pm.x = 1;
        else
            pm.x = -1;
        if (gyro.y > defY)
            pm.y = 1;
        else
            pm.y = -1;

        pm *= PM;

        accelerationCount.x = (int)(Mathf.Abs(gyro.x) / (gyroLimit.x / maxAcceleration.x));
        if (gyro.y > defY)
            accelerationCount.y = (int)(Mathf.Abs(gyro.y) / (gyroLimit.y - defY / maxAcceleration.y));
        else
            accelerationCount.y = (int)(Mathf.Abs(gyro.y) / (defY / maxAcceleration.y));
        debugText.GetComponent<DebugText>().text = accelerationCount.x.ToString() + "\n" + accelerationCount.y.ToString();

        if (Mathf.Abs(transform.position.x + accelerationCount.x * (speedV2.y / maxAcceleration.x) * pm.x) < limit.x)
            v3.x = transform.position.x + accelerationCount.x * (speedV2.y / maxAcceleration.x) * pm.x;
        else
            v3.x = transform.position.x;
        if (Mathf.Abs(transform.position.y + accelerationCount.y * (speedV2.y / maxAcceleration.y) * pm.y) < limit.y)
            v3.y = transform.position.y + accelerationCount.y * (speedV2.y / maxAcceleration.y) * pm.y;
        else
            v3.y = transform.position.y;
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
