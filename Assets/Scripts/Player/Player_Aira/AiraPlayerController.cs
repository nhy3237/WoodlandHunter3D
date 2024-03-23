using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerController : MonoBehaviour, IPlayerController
{
    [Header("move Speed")]
    public float moveSpeed = 1f;

    private StateMachine<AiraPlayerController> stateMachine;
    private Animator animator;

    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();

        stateMachine = new StateMachine<AiraPlayerController>();
        stateMachine.Setup(this, new AiraPlayerIdleState(animator));
    }

    private void Update()
    {
        stateMachine.Execute();
    }

    public void ChangeIdleState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(new AiraPlayerIdleState(animator));
        }
    }

    public void ChangeWalkState()
    {

        if (animator != null)
        {
            stateMachine.ChangeState(new AiraPlayerWalkState(animator, moveSpeed));
        }
    }

    public void ChangeJumpState()
    {

        if (animator != null)
        {
            stateMachine.ChangeState(new AiraPlayerJumpState(animator));
        }
    }
}
