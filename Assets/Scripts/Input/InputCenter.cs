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

    void Start()
    { 
        playerController = dataManager.GetPlayerObject().GetComponentInChildren<IPlayerController>();

        inputHandler.OnPlayerWalkInput += ChangeWalkState;
        inputHandler.OnPlayerRunInput += ChangeRunState;
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerJumpInput += ChangeJumpState;
        inputHandler.OnPlayerAttackInput += ChangeAttackState;
        inputHandler.OnPlayerMeleeAttackInput += ChangeMeleeAttackState;
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

    void ChangeRunState()
    {
        playerController?.ChangeRunState();
    }

    void ChangeJumpState()
    {
        playerController?.ChangeJumpState();
    }

    void ChangeAttackState()
    {
        playerController?.ChangeAttackState();
    }

    void ChangeMeleeAttackState()
    {
        playerController?.ChangeMeleeAttackState();
    }
}
