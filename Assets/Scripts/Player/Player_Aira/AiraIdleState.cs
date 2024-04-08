using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraIdleState : State<PlayerController>
{
    private Animator animator;

    public AiraIdleState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(PlayerController entity)
    {
        entity.GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
        animator.SetBool("IsWalking", false);
    }

    public override void Execute(PlayerController entity)
    {

    }

    public override void Exit(PlayerController entity)
    {
    }
}
