using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerJumpState : State<AiraPlayerController>
{
    private Animator animator;

    public AiraPlayerJumpState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(AiraPlayerController entity)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
            && !animator.GetNextAnimatorStateInfo(0).IsName("Jump"))
        {
            animator.SetTrigger("Jump");
        }
    }

    public override void Execute(AiraPlayerController entity)
    {

    }

    public override void Exit(AiraPlayerController entity)
    {
         
    }
}
