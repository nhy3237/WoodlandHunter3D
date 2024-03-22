using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayerWalkState : State<ArcherPlayerController>
{

    private Animator animator;

    public ArcherPlayerWalkState(Animator animator)
    {

        this.animator = animator;
    }

    Vector3 movement;

    public override void Enter(ArcherPlayerController entity)
    {
        animator.SetBool("IsWalking", true);
    }

    public override void Execute(ArcherPlayerController entity)
    {
        movement.x = animator.GetFloat("XDir");
        movement.z = animator.GetFloat("YDir");

        entity.transform.Translate(movement * entity.speed * Time.deltaTime);

    }

    public override void Exit(ArcherPlayerController entity)
    {
        animator.SetBool("IsWalking", false);
    }
}
