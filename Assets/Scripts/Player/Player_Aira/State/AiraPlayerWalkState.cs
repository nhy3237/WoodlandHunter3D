using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerWalkState : State<AiraPlayerController>
{
    private Animator animator;
    private float moveSpeed;

    public AiraPlayerWalkState(Animator animator, float moveSpeed)
    {
        this.animator = animator;
        this.moveSpeed = moveSpeed;
    }

    public override void Enter(AiraPlayerController entity)
    {
        animator.SetBool("IsWalking", true);
    }

    public override void Execute(AiraPlayerController entity)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        entity.transform.parent.Translate(movement * moveSpeed * Time.deltaTime);

        animator.SetFloat("Horizontal", horizontalInput);
    }

    public override void Exit(AiraPlayerController entity)
    {
        animator.SetBool("IsWalking", false);
    }
}
