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
        if (!
            animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
            && !animator.GetNextAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("Attack");
        }
    }

    public override void Execute(AiraPlayerController entity)
    {
        //entity.attackParticle.SetActive(true);
    }

    public override void Exit(AiraPlayerController entity)
    {
        //entity.attackParticle.SetActive(false);
    }
}
