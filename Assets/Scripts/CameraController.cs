using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject CameraGoalLookAt;
    public GameObject CameraGoalPosition;
    public Vector3 CameraCurrentLookAt;

    public float MovementDividor;
    public float LookAtDividor;

    void LateUpdate()
    {
        if(CameraGoalPosition!=null && CameraGoalLookAt != null)
        {
            // Camera Movement
            Vector3 movement = CameraGoalPosition.transform.position - transform.position;
            movement = movement / MovementDividor;
            transform.position += movement;

            // Camera Look At
            Vector3 movementA = CameraGoalLookAt.transform.position - CameraCurrentLookAt;
            movementA = movementA / LookAtDividor;
            CameraCurrentLookAt += movementA;
            transform.LookAt(CameraCurrentLookAt);
        }
    }
}