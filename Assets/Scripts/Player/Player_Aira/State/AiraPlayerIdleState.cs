using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerIdleState : State<AiraPlayerController>
{
    private Animator animator;

    public AiraPlayerIdleState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(AiraPlayerController entity)
    {
        //entity.GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
        animator.SetBool("IsWalking", false);
        entity.attackParticle.SetActive(false);
    }

    public override void Execute(AiraPlayerController entity)
    {
        animator.SetBool("IsWalking", false);
    }

    public override void Exit(AiraPlayerController entity)
    {
    }
}
