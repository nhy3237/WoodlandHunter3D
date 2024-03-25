using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerWalkState : State<VianPlayerController>
{

    private Animator animator;

    public VianPlayerWalkState(Animator animator)
    {

        this.animator = animator;
    }

    Vector3 movement;

    public override void Enter(VianPlayerController entity)
    {
        animator.SetBool("IsWalking", true);
    }

    public override void Execute(VianPlayerController entity)
    {
        movement.x = animator.GetFloat("XDir");
        movement.z = animator.GetFloat("YDir");

        entity.transform.Translate(movement * entity.speed * Time.deltaTime);

    }

    public override void Exit(VianPlayerController entity)
    {
    }
}
