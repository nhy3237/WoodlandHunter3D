using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerWalkState : State<AiraPlayerController>
{
    private Animator animator;

    public AiraPlayerWalkState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(AiraPlayerController entity)
    {
        animator.SetBool("IsWalking", true);
    }

    public override void Execute(AiraPlayerController entity)
    {
        entity.transform.parent.Translate(entity.movement * entity.moveSpeed * Time.deltaTime);

        animator.SetFloat("Horizontal", entity.movement.x);
    }

    public override void Exit(AiraPlayerController entity)
    {
        animator.SetBool("IsWalking", false);
    }
}
