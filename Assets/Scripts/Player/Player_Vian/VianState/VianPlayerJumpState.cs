using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerJumpState : State<VianPlayerController>
{

    private Animator animator;

    public VianPlayerJumpState(Animator animator)
    {
        this.animator = animator;
    }


    public override void Enter(VianPlayerController entity)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
            && !animator.GetNextAnimatorStateInfo(0).IsName("Jump"))
        {
            animator.SetTrigger("Jump");
        }
        
    }

    public override void Execute(VianPlayerController entity)
    {


    }

    public override void Exit(VianPlayerController entity)
    {
        entity.ISJUMPING = false;
    }
}
