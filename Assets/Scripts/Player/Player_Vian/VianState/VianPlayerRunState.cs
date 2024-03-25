using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerRunState : State<VianPlayerController>
{
    private Animator animator;

    public VianPlayerRunState(Animator animator)
    {
        this.animator = animator;
    }

    Vector3 movement;
    float runSpeed;

    public override void Enter(VianPlayerController entity)
    {
        animator.SetBool("IsRunning", true);
    }

    public override void Execute(VianPlayerController entity)
    {
        movement.x = animator.GetFloat("XDir");
        movement.y = animator.GetFloat("YDir");

        runSpeed = entity.speed * 2;
        entity.transform.Translate(movement * runSpeed * Time.deltaTime);

    }

    public override void Exit(VianPlayerController entity)
    {
        animator.SetBool("IsRunning", false);
    }
}
