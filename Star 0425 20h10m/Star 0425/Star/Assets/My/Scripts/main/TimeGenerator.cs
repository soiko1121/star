using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player, target;
    private PlayerMove playerMove;
    private float minAngle, maxAngle, rotaTimer, distance, height, cameraMaxAngle, cameraMinAngle;

    public float changeTime;
    public bool cameraMoveNow, zoneHit;
    // Start is called before the first frame update
    void Start()
    {
        cameraMoveNow = false;
        rotaTimer = 0.0f;
        zoneHit = false;
        playerMove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!zoneHit)
        {
            return;
        }
        if (!cameraMoveNow)
        {
            switch (playerMove.viewSet)
            {
                case PlayerMove.View.back:
                    playerMove.viewSet = PlayerMove.View.side;
                    playerMove.set2DSpeed = player.transform.position.x / 60.0f;
                    break;
                case PlayerMove.View.side:
                    playerMove.viewSet = PlayerMove.View.back;
                    playerMove.set2DSpeed = player.transform.position.z / 60.0f;
                    mainCamera.orthographic = !mainCamera.orthographic;
                    break;
                default:
                    break;
            }
            cameraMoveNow = true;
            Time.timeScale = 0f;
        }
        else
        {
            CameraMove();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            zoneHit = true;
        }
    }
    private void CameraMove()
    {
        //mainCamera.transform.LookAt(player.transform);
        switch (playerMove.viewSet)
        {
            case PlayerMove.View.back:
                minAngle = -90.0f;
                maxAngle = 0f;
                cameraMinAngle = 0f;
                cameraMaxAngle = 10f;
                distance = 0f;
                height = 4f;
                break;
            case PlayerMove.View.side:
                minAngle = 0f;
                maxAngle = -90f;
                cameraMinAngle = 10f;
                cameraMaxAngle = 0f;
                distance = 17f;
                height = 0f;
                break;
            default:
                break;
        }

        rotaTimer += 1 / 60.0f;
        float angle = Mathf.LerpAngle(minAngle, maxAngle, rotaTimer);
        float cameraAngle = Mathf.LerpAngle(cameraMinAngle, cameraMaxAngle, rotaTimer);
        target.transform.eulerAngles = new Vector3(cameraAngle, angle, 0);
        target.transform.position = new Vector3(0, height * rotaTimer, distance * rotaTimer);

        if (rotaTimer >= 1f)
        {
            rotaTimer = 0;
            cameraMoveNow = false;
            Time.timeScale = 1f;
            zoneHit = false;
            if (playerMove.viewSet == PlayerMove.View.side)
            {
                mainCamera.orthographic = !mainCamera.orthographic;
            }
        }
    }
}
