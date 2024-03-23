using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerWalkState : State<AiraPlayerController>
{
    private Animator animator;
    private float moveSpeed;

    public AiraPlayerWalkState(Animator animator, float moveSpeed)
    {
        this.animator = animator;
        this.moveSpeed = moveSpeed;
    }

    public override void Enter(AiraPlayerController entity)
    {
        animator.SetBool("IsWalking", true);
    }

    public override void Execute(AiraPlayerController entity)
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        entity.transform.Translate(movement);
    }

    public override void Exit(AiraPlayerController entity)
    {
        animator.SetBool("IsWalking", false);
    }
}
