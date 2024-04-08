using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private DataManager dataManager;

    private IPlayerController playerController;
    private CameraController cameraController;

    void Start()
    { 
        playerController = dataManager.GetPlayerObject().GetComponentInChildren<IPlayerController>();
        cameraController = dataManager.GetPlayerObject().GetComponentInChildren<CameraController>();

        inputHandler.OnPlayerWalkInput += ChangeWalkState;
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerJumpInput += ChangeJumpState;
        inputHandler.OnPlayerAttackInput += ChangeAttackState;
        inputHandler.OnCameraRotateInput += ChangeCameraRotate;
    }

    void OnDestroy()
    {
    }

    void ChangeIdleState()
    {
        playerController?.ChangeIdleState();
    }

    void ChangeWalkState()
    {
        playerController?.ChangeWalkState(inputHandler.GetMovement());
    }

    void ChangeJumpState()
    {
        playerController?.ChangeJumpState();
    }

    void ChangeAttackState()
    {
        playerController?.ChangeAttackState();
    }

    void ChangeCameraRotate()
    {
        cameraController?.ChangeCameraRotate(inputHandler.GetMouseX());
    }
}
