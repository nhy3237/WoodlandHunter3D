using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerRangedAttackReadyState : State<VianPlayerController>
{
    private Animator animator;

    public VianPlayerRangedAttackReadyState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(VianPlayerController entity)
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot")
            &&  !animator.GetCurrentAnimatorStateInfo(0).IsName("ShootReady"))
        {
            animator.SetTrigger("RangedAttackReady");

        }
    }

    public override void Execute(VianPlayerController entity)
    {

    }

    public override void Exit(VianPlayerController entity)
    {

    }
}
