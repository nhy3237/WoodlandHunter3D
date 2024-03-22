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
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerJumpInput += ChangeJumpState;

    }

    void ChangeIdleState()
    {
        archerPlayerController.stateMachine.ChangeState(new ArcherPlayerIdleState(archerPlayerController.animator));
    }

    void ChangeWalkState()
    {
        archerPlayerController.animator.SetFloat("XDir", inputHandler.GetMovement().x);
        archerPlayerController.animator.SetFloat("YDir", inputHandler.GetMovement().y);

        archerPlayerController.stateMachine.ChangeState(new ArcherPlayerWalkState(archerPlayerController.animator));
    }

    void ChangeJumpState()
    {
        
        if (!archerPlayerController.ISJUMPING)
        {
            Debug.Log("jump");
            archerPlayerController.ISJUMPING = true;
            archerPlayerController.stateMachine.ChangeState(new ArcherPlayerJumpState(archerPlayerController.animator));

        }

    }
}
