using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float horizontalRotationSpeed;
    public float playerDistance = 3f;
    public float rotationSensitivity = 3f;
    public Transform player;

    private float smoothRotationTime = 0.12f;
    private float cameraHeight = 1.7f;
    private Vector3 targetRotation;
    private Vector3 currentVelocity;


    public void ChangeCameraRotate(float mouseX)
    {
        horizontalRotationSpeed = horizontalRotationSpeed + mouseX * rotationSensitivity;
        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(0f, horizontalRotationSpeed), ref currentVelocity, smoothRotationTime);
        this.transform.eulerAngles = targetRotation;

        Vector3 playerEulerAngles = new Vector3(0f, targetRotation.y, 0f);
        player.rotation = Quaternion.Euler(playerEulerAngles);

        transform.position = player.position - transform.forward * playerDistance;
        transform.position = new Vector3(transform.position.x, cameraHeight, transform.position.z);
    }
}
