using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("MeleeAttack")
           && !animator.GetNextAnimatorStateInfo(0).IsName("MeleeAttack"))
        {
            animator.SetTrigger("MeleeAttackStart");
            animator.SetBool("IsMeleeAttacking", true);

        }
    }

    public override void Execute(VianPlayerController entity)
    {
    }

    public override void Exit(VianPlayerController entity)
    {
        animator.SetBool("IsMeleeAttacking", false);
    }

}
