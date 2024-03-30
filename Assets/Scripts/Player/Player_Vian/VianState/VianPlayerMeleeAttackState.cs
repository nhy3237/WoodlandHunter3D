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
        animator.SetTrigger("MeleeAttackStart");
        //animator.SetBool("IsMeleeAttacking", true);
        Debug.Log("IsMeleeAttacking Start");

    }

    public override void Execute(VianPlayerController entity)
    {
        Debug.Log("IsMeleeAttacking...");
    }

    public override void Exit(VianPlayerController entity)
    {
        //animator.SetBool("IsMeleeAttacking", false);
        Debug.Log("IsMeleeAttacking Exit");
    }

}
