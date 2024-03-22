using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayerJumpState : State<ArcherPlayerController>
{

    private Animator animator;

    public ArcherPlayerJumpState(Animator animator)
    {
        this.animator = animator;
    }


    public override void Enter(ArcherPlayerController entity)
    {
        animator.SetTrigger("Jump");
    }

    public override void Execute(ArcherPlayerController entity)
    {


    }

    public override void Exit(ArcherPlayerController entity)
    {
        entity.ISJUMPING = false;
    }
}
