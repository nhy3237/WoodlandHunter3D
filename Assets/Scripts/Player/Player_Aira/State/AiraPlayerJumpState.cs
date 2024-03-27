using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerJumpState : State<AiraPlayerController>
{
    private Animator animator;
    private bool isJumping = false;
    private bool chkJump = false;

    public AiraPlayerJumpState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(AiraPlayerController entity)
    {
        if(!isJumping)
        {
            animator.SetTrigger("Jump");
            isJumping = true;
        }
    }

    public override void Execute(AiraPlayerController entity)
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            chkJump = true;
        }
        if (chkJump && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            isJumping = false;
            chkJump = false;
        }
    }

    public override void Exit(AiraPlayerController entity)
    {
         
    }
}
