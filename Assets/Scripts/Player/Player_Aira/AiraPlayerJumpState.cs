using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerJumpState : State<AiraPlayerController>
{
    private Animator animator;

    public AiraPlayerJumpState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(AiraPlayerController entity)
    {
        animator.SetTrigger("Jump");
        entity.GetComponentInParent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }

    public override void Execute(AiraPlayerController entity)
    {

    }

    public override void Exit(AiraPlayerController entity)
    {
    }
}
