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


    public override void Enter(VianPlayerController entity)
    {
        animator.SetBool("IsWalking", true);

        animator.SetFloat("XDir", entity.moveDirection.x);
    }

    public override void Execute(VianPlayerController entity)
    {


        entity.transform.Translate(entity.moveDirection * entity.speed * Time.deltaTime);

    }

    public override void Exit(VianPlayerController entity)
    {
    }
}
