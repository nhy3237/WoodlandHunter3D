using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerMeleeAttackState : State<VianPlayerController>
{
    private Animator animator;

    public VianPlayerMeleeAttackState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(VianPlayerController entity)
    {
        animator.SetBool("IsMeleeAttacking", true);
        Debug.Log("Attack Start");
    }

    public override void Execute(VianPlayerController entity)
    {
        Debug.Log("Attacking...");

    }

    public override void Exit(VianPlayerController entity)
    {
        animator.SetBool("IsMeleeAttacking", false);
        Debug.Log("Attack End");

    }
}
