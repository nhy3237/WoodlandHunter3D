using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PixelCrushers.DialogueSystem.UnityGUI.GUIProgressBar;

public class InputCenter : MonoBehaviour
{
    [SerializeField] public ArcherPlayerController archerPlayerController;
    [SerializeField] public InputHandler inputHandler;

    private void Start()
    {
        inputHandler.OnPlayerWalkInput += ChangeWalkState;
        inputHandler.OnPlayerDashInput += ChangeDashState;
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerJumpInput += ChangeJumpState;
    }

    void ChangeIdleState()
    {
        archerPlayerController.archerPlayerStateMachine.ChangeState(PlayerEnum.Idle);
    }

    void ChangeWalkState()
    {
        archerPlayerController.archerPlayerStateMachine.ChangeState(PlayerEnum.Walk);
    }

    void ChangeDashState()
    {
        archerPlayerController.archerPlayerStateMachine.ChangeState(PlayerEnum.Run);
    }
    void ChangeJumpState()
    {
        if(!archerPlayerController.ISJUMPING)
        {
            Debug.Log("jump");
            archerPlayerController.ISJUMPING = true;
            archerPlayerController.archerPlayerStateMachine.ChangeState(PlayerEnum.Jump);
        }

    }
}
