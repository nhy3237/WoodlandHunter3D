using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerRangedAttackState : State<VianPlayerController>
{
    private Animator animator;

    public VianPlayerRangedAttackState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(VianPlayerController entity)
    {
        animator.SetBool("IsRangeAttacking", true);
    }

    public override void Execute(VianPlayerController entity)
    {

    }

    public override void Exit(VianPlayerController entity)
    {
        animator.SetBool("IsRangedAttacking", false);
    }
}
