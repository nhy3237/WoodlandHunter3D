using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    [SerializeField]
    private PlayerType selectedPlayerType;
    [SerializeField]
    private InputHandler inputHandler;

    private IPlayerController playerController;

    void Start()
    {
        GameManager.instance.OnPlayerObjectChanged += UpdatePlayer;

        inputHandler.OnPlayerWalkInput += ChangeWalkState;
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerJumpInput += ChangeJumpState;
        inputHandler.OnPlayerAttackInput += ChangeAttackState;
    }

    void OnDestroy()
    {
        GameManager.instance.OnPlayerObjectChanged -= UpdatePlayer;
    }

    private void UpdatePlayer()
    {
        playerController = GameManager.instance.GetPlayerController();
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
}
