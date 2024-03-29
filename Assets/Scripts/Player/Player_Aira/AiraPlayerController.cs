using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerController : MonoBehaviour, IPlayerController
{
    [Header("Move Speed")]
    public float moveSpeed = 1f;

    [Header("Attack Paticle")]
    public GameObject attackParticle;

    private StateMachine<AiraPlayerController> stateMachine;
    private AiraPlayerIdleState idleState;
    private AiraPlayerWalkState walkState;
    private AiraPlayerJumpState jumpState;
    private AiraPlayerAttackState attackState;
    private Animator animator;

    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();

        stateMachine = new StateMachine<AiraPlayerController>();
        idleState = new AiraPlayerIdleState(animator);
        walkState = new AiraPlayerWalkState(animator, moveSpeed);
        jumpState = new AiraPlayerJumpState(animator);
        attackState = new AiraPlayerAttackState(animator);
        stateMachine.Setup(this, idleState);
    }

    private void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            stateMachine.ChangeState(jumpState);
        }
        stateMachine.Execute();
    }

    public void ChangeIdleState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(idleState);
        }
    }

    public void ChangeWalkState(Vector3 movement)
    {
        if (animator != null)
        {
            stateMachine.ChangeState(walkState);
        }
    }

    public void ChangeJumpState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(jumpState);
        }
    }

    public void ChangeAttackState()
    {
        if(animator != null)
        {
            stateMachine.ChangeState(attackState);
        }
    }
}
