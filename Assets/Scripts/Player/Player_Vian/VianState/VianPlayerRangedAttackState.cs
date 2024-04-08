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
        animator.SetTrigger("RangedAttack");
    }

    public override void Execute(VianPlayerController entity)
    {

    }

    public override void Exit(VianPlayerController entity)
    {

    }
}
