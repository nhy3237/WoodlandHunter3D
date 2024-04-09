using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class VianPlayerController : MonoBehaviour, IPlayerController
{

    [Header("플레이어 상태 기계")]

    [SerializeField]
    private GameObject meleeAttackParticleObject;
    [SerializeField]
    private GameObject arrowPrefab;
    [SerializeField]
    private Transform arrowSpawnPoint;

    private StateMachine<VianPlayerController> stateMachine;
    private ParticleSystem meleeAttackParticleSystem;
    private Animator animator;

    private VianPlayerIdleState idleState;
    private VianPlayerWalkState walkState;
    private VianPlayerRunState runState;
    private VianPlayerJumpState jumpState;
    private VianPlayerMeleeAttackState meleeAttackState;
    private VianPlayerRangedAttackReadyState rangedAttackReadyState;
    private VianPlayerRangedAttackState rangedAttackState;

    private Vector3 originPos;
    private int hp = 100;

    public float jumpPower = 2;
    public bool IsJumping = false;
    public Vector3 moveDirection;
    public float speed = 0.5f;
    public float rotationSpeed = 0.5f; // 회전 속도

    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public bool ISJUMPING
    {
        get { return IsJumping; }
        set { IsJumping = value; }
    }


    void Start()
    {
        originPos = transform.position;
        animator = transform.GetComponent<Animator>();

        stateMachine = new StateMachine<VianPlayerController>();

        idleState = new VianPlayerIdleState(animator);
        walkState = new VianPlayerWalkState(animator);
        runState = new VianPlayerRunState(animator);
        jumpState = new VianPlayerJumpState(animator);
        meleeAttackState = new VianPlayerMeleeAttackState(animator);
        rangedAttackReadyState = new VianPlayerRangedAttackReadyState(animator);
        rangedAttackState = new VianPlayerRangedAttackState(animator);

        stateMachine.Setup(this, idleState);

        meleeAttackParticleSystem = meleeAttackParticleObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        stateMachine.Execute();

        if(animator.GetBool("IsMeleeAttacking"))
        {
            StartCoroutine(PlayPaticle());
        }
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
        moveDirection = movement;
        if (animator != null)
        {
            stateMachine.ChangeState(walkState);
        }
    }

    public void ChangeRunState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(runState);
        }
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
       
    }

    public void ChangeMeleeAttackState()
    {
        if (animator != null && !animator.GetBool("IsMeleeAttacking"))
        {
            stateMachine.ChangeState(meleeAttackState);
        }
    }

    public void ChangeRangedAttackReadyState()
    {
        if(animator != null)
        {
            stateMachine.ChangeState(rangedAttackReadyState);
            CreateArrow();
        }
    }

    public void ChangeRangedAttackState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(rangedAttackState);
        }

    }

    private void CreateArrow()
    {
        Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
    }


    IEnumerator PlayPaticle()
    {
        yield return new WaitForSeconds(0.6f);
        meleeAttackParticleSystem.Play();
    }

    public void ResetPosition()
    {
        transform.position = originPos;
    }

    public void SetSpeed(float Speed)
    {
        speed = Speed;
    }

    void FloorCollisionHandler(Collider ohter)
    {
        IsJumping = false;
    }

}
