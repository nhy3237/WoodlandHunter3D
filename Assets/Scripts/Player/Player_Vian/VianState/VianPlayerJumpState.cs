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
        animator.SetTrigger("Jump");
    }

    public override void Execute(VianPlayerController entity)
    {


    }

    public override void Exit(VianPlayerController entity)
    {
        entity.ISJUMPING = false;
    }
}
