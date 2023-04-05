using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;

    public Room currRoom;

    public float accelerationTime = 0.2f;
    public float maxSpeed = 10f;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if (currRoom == null)
        {
            return;
        }

        Vector3 targetPos = GetCameraTargetPosition();

        // Use SmoothDamp to apply a smooth acceleration to the movement
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, accelerationTime, maxSpeed);
    }

    Vector3 GetCameraTargetPosition()
    {
        if (currRoom == null)
        {
            
            return Vector3.zero;
        }
        Vector3 targetPos = currRoom.GetRoomCentre();

        targetPos.z = transform.position.z;
        return targetPos;
    }

    public bool IsSwitchingScene()
    {
        return transform.position.Equals(GetCameraTargetPosition()) == false;
    }
}
