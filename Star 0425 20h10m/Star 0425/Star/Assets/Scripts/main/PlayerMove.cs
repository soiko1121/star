using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public Animator anime;
    private Vector3 gyro, gyroSet, moveVec, velocitySet;
    private Rigidbody playerRB;
    public float speed, slowdown, set2DSpeed;
    public DebugText debugText;
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

        //anime = GetComponent<Animator>();

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
            gyro.x = Mathf.Clamp(Input.gyro.gravity.x * 2.0f, -9.8f, 9.8f);
            gyro.y = Mathf.Clamp(((Input.gyro.gravity.z + 0.8f) * 2.0f), -9.8f, 9.8f);
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
            accelerationCount.x = (Mathf.Abs(gyro.x) / (9.8f / maxAcceleration.x));
            accelerationCount.y = (Mathf.Abs(gyro.y) / (9.8f / maxAcceleration.y));
            if (viewSet == View.back)
            {
                transform.position = new Vector3(
                    transform.position.x + accelerationCount.x * (9.8f / maxAcceleration.x) * speed * pm.x,
                    transform.position.y + accelerationCount.y * (9.8f / maxAcceleration.y) * speed * pm.y,
                    0);
            }
            else
            {
                transform.position = new Vector3(
                    0,
                    transform.position.y + accelerationCount.y * (9.8f / maxAcceleration.y) * speed * pm.y,
                    transform.position.z + accelerationCount.x * (9.8f / maxAcceleration.x) * speed * pm.x);
            }
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
            if (transform.position.z < -2)
            {
                v3.z = -2;
            }
            if (transform.position.z > 2)
            {
                v3.z = 2;
            }
            transform.position = v3;
            //Animation();
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
        }
        PosList.Add(transform.position);
        if (PosList.Count > 200 * 10)
        {
            PosList.RemoveAt(0);
        }
    }
    //private void Animation()
    //{
    //    if (gyro.x > 0)
    //    {
    //        anime.SetBool("IsRight", true);
    //        anime.SetBool("IsLeft", false);
    //    }
    //    else
    //    {
    //        anime.SetBool("IsLeft", true);
    //        anime.SetBool("IsRight", false);
    //    }
    //    anime.SetBool("IsFloat", false);
    //}
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
