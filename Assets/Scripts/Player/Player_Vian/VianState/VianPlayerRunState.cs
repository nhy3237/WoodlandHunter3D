using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerRunState : State<VianPlayerController>
{
    private Animator animator;

    public VianPlayerRunState(Animator animator)
    {
        this.animator = animator;
    }

    float runSpeed;

    public override void Enter(VianPlayerController entity)
    {
        animator.SetBool("IsRunning", true);
    }

    public override void Execute(VianPlayerController entity)
    {

        runSpeed = entity.speed * 3;
        entity.transform.Translate(entity.moveDirection * runSpeed * Time.deltaTime);

    }

    public override void Exit(VianPlayerController entity)
    {
        animator.SetBool("IsRunning", false);
    }
}
