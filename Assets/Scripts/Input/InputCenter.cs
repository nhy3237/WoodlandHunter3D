using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    [SerializeField] public VianPlayerController vianPlayerController;
    [SerializeField] public InputHandler inputHandler;

    private void Start()
    {
        inputHandler.OnPlayerWalkInput += ChangeWalkState;
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerJumpInput += ChangeJumpState;
        inputHandler.OnPlayerRunInput += ChangeRunState;

        inputHandler.OnPlayerMeleeAttackInput += ChangeMeleeAttackState;
        inputHandler.OnPlayerRangedAttackReadyInput += ChangeRangedAttackReadyState;
        inputHandler.OnPlayerRangedAttackInput += ChangeRangedAttackState;
    }

    void ChangeIdleState()
    {
        vianPlayerController.stateMachine.ChangeState(new VianPlayerIdleState(vianPlayerController.animator));
    }

    void ChangeWalkState()
    {
        vianPlayerController.animator.SetFloat("XDir", inputHandler.GetMovement().x);
        vianPlayerController.animator.SetFloat("YDir", inputHandler.GetMovement().y);

        vianPlayerController.stateMachine.ChangeState(new VianPlayerWalkState(vianPlayerController.animator));
    }

    void ChangeJumpState()
    {

        if (!vianPlayerController.ISJUMPING)
        {
            Debug.Log("jump");
            vianPlayerController.ISJUMPING = true;
            vianPlayerController.stateMachine.ChangeState(new VianPlayerJumpState(vianPlayerController.animator));

        }

    }

    void ChangeRunState()
    {
        vianPlayerController.animator.SetFloat("XDir", inputHandler.GetMovement().x);
        vianPlayerController.animator.SetFloat("YDir", inputHandler.GetMovement().y);

        vianPlayerController.stateMachine.ChangeState(new VianPlayerRunState(vianPlayerController.animator));
    }

    void ChangeMeleeAttackState()
    {
        vianPlayerController.stateMachine.ChangeState(new VianPlayerMeleeAttackState(vianPlayerController.animator));
    }

    void ChangeRangedAttackReadyState()
    {
        if(!vianPlayerController.animator.GetBool("IsRangedAttackReady"))
            vianPlayerController.stateMachine.ChangeState(new VianPlayerRangedAttackReadyState(vianPlayerController.animator));

    }

    void ChangeRangedAttackState()
    {
        vianPlayerController.stateMachine.ChangeState(new VianPlayerRangedAttackState(vianPlayerController.animator));

    }

}
