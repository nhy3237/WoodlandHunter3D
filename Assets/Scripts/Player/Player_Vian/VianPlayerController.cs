using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerController : MonoBehaviour
{

    [Header("플레이어 상태 기계")]
    //[SerializeField] public ArcherPlayerStateMachine archerPlayerStateMachine;
    public StateMachine<VianPlayerController> stateMachine;

    [SerializeField] public Rigidbody rigid;
    [SerializeField] public Animator animator;
    //[SerializeField] private NotifyCollisionToPlayer collisionWithFloor;

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

        stateMachine = new StateMachine<VianPlayerController>();
        stateMachine.Setup(this, new VianPlayerIdleState(animator));
    }

    void FixedUpdate()
    {
        stateMachine.Execute();
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
