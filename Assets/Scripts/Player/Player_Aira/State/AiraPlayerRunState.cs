using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerRunState : State<AiraPlayerController>
{
    private Animator animator;

    public AiraPlayerRunState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(AiraPlayerController entity)
    {
        animator.SetBool("IsRunning", true);
    }

    public override void Execute(AiraPlayerController entity)
    {

        float runSpeed = entity.moveSpeed * 3;

        entity.transform.parent.Translate(entity.movement * runSpeed * Time.deltaTime);

        animator.SetFloat("Horizontal", entity.movement.x);
    }

    public override void Exit(AiraPlayerController entity)
    {
        animator.SetBool("IsRunning", false);
    }
}
