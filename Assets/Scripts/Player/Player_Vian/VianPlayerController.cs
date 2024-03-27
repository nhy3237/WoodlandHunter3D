using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class VianPlayerController : MonoBehaviour, IPlayerController
{

    [Header("플레이어 상태 기계")]
    //[SerializeField] public ArcherPlayerStateMachine archerPlayerStateMachine;
    public StateMachine<VianPlayerController> stateMachine;
    public GameObject meleeAttackParticleObject;
    private ParticleSystem meleeAttackParticleSystem;
    //public GameObject arrowPrefab;
    [SerializeField] public Rigidbody rigid;
    private Animator animator;
    //[SerializeField] private NotifyCollisionToPlayer collisionWithFloor;

    private VianPlayerIdleState idleState;
    private VianPlayerWalkState walkState;
    private VianPlayerJumpState jumpState;
    private VianPlayerMeleeAttackState meleeAttackState;
    private VianPlayerRangedAttackReadyState rangedAttackReadyState;
    private VianPlayerRangedAttackState rangedAttackState;

    public float jumpPower = 2;
    public bool IsJumping = false;


    public Vector3 moveDirection;
    public float speed = 1f;
    public float rotationSpeed = 0.5f; // 회전 속도

    private Vector3 originPos;

   

    int hp = 100;

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
        //collisionWithFloor.OnCollision += FloorCollisionHandler;
        animator = transform.GetComponent<Animator>();

        stateMachine = new StateMachine<VianPlayerController>();
        idleState = new VianPlayerIdleState(animator);
        walkState = new VianPlayerWalkState(animator);
        jumpState = new VianPlayerJumpState(animator);
        meleeAttackState = new VianPlayerMeleeAttackState(animator);
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


        if(animator.GetBool("IsRangedAttacking"))
        {
            //GameObject t_arrow = Instantiate(arrowPrefab);
            //t_arrow.GetComponent<Rigidbody>().velocity = m_tfArrow.transform.right * 10f;

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

    public void ChangeJumpState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(jumpState);
        }
    }

    public void ChangeAttackState()
    {
        if (animator != null)
        {
            stateMachine.ChangeState(meleeAttackState);
        }
    }


    IEnumerator PlayPaticle()
    {
        yield return new WaitForSeconds(0.6f);
        meleeAttackParticleSystem.Play();
    }

    public void MoveInput()
    {

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
