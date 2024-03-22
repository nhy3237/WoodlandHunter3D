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
        archerPlayerController.archerPlayerStateMachine.ChangeState(ArcherPlayerEnum.Idle);
    }

    void ChangeWalkState()
    {
        archerPlayerController.archerPlayerStateMachine.ChangeState(ArcherPlayerEnum.Walk);
    }

    void ChangeDashState()
    {
        archerPlayerController.archerPlayerStateMachine.ChangeState(ArcherPlayerEnum.Run);
    }
    void ChangeJumpState()
    {
        
        if (!archerPlayerController.ISJUMPING)
        {
            Debug.Log("jump");
            archerPlayerController.ISJUMPING = true;
            archerPlayerController.archerPlayerStateMachine.ChangeState(ArcherPlayerEnum.Jump);

        }

    }
}
