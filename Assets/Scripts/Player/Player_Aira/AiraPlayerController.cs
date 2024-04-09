using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiraPlayerController : MonoBehaviour, IPlayerController
{
    [Header("Move Speed")]
    public float moveSpeed = 1f;

    [Header("Attack Paticle")]
    public GameObject attackParticle;

    private StateMachine<AiraPlayerController> stateMachine;
    private AiraPlayerIdleState idleState;
    private AiraPlayerWalkState walkState;
    private AiraPlayerRunState runState;
    private AiraPlayerJumpState jumpState;
    private AiraPlayerAttackState attackState;
    private Animator animator;
    private Transform cameraTransform;

    public Vector3 movement;

    void Start()
    {
        cameraTransform = Camera.main.transform;

        animator = transform.parent.GetComponent<Animator>();

        stateMachine = new StateMachine<AiraPlayerController>();
        idleState = new AiraPlayerIdleState(animator);
        walkState = new AiraPlayerWalkState(animator);
        runState = new AiraPlayerRunState(animator);
        jumpState = new AiraPlayerJumpState(animator);
        attackState = new AiraPlayerAttackState(animator);
        stateMachine.Setup(this, idleState);
    }

    private void Update()
    {
        Vector2 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (inputDir != Vector2.zero)
        {
            float inputAngle = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            float rotation = inputAngle + cameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, rotation, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, rotation, 0f) * Vector3.forward;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            stateMachine.ChangeState(jumpState);
        }
        stateMachine.Execute();
    }

    public void ChangeIdleState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(idleState);
        }
    }

    public void ChangeWalkState(Vector3 movement)
    {
        if (animator != null)
        {
            this.movement = movement;
            stateMachine.ChangeState(walkState);
        }
    }

    public void ChangeRunState()
    {
        if(animator != null)
        {
            stateMachine.ChangeState(runState);
        }
    }

    public void ChangeMeleeAttackState()
    {

    }

    public void ChangeJumpState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(jumpState);
        }
    }

    public void ChangeAttackState()
    {
        if(animator != null)
        {
            stateMachine.ChangeState(attackState);
        }
    }
}
