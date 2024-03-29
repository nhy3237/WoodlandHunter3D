using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerAttackState : State<AiraPlayerController>
{
    private Animator animator;

    public AiraPlayerAttackState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(AiraPlayerController entity)
    {

    }

    public override void Execute(AiraPlayerController entity)
    {
        animator.SetTrigger("Attack");
        entity.attackParticle.SetActive(true);
    }

    public override void Exit(AiraPlayerController entity)
    {

    }
}
