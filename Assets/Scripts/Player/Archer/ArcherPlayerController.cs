using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayerController : MonoBehaviour
{

    [Header("플레이어 상태 기계")]
    [SerializeField] public ArcherPlayerStateMachine archerPlayerStateMachine;
    [SerializeField] public Rigidbody rigid;
    [SerializeField] public Collider legCollider;
    [SerializeField] public Animator animator;
    public Vector3 moveDirection;
    public float speed = 1f;
    public float rotationSpeed = 0.5f; // 회전 속도
    public float jumpPower = 10;
    public bool IsJumping = false;

    private Vector3 originPos;


    int hp = 100;

    public delegate void PlayerHandle();
    public event PlayerHandle OnPlayerMonsterCollision;
    public event PlayerHandle OnPlayerChestCollision;

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

    bool isChestAnim = false;

    public bool ChestAnim
    {
        get { return isChestAnim; }
        set { isChestAnim = value; }
    }

    void Start()
    {
        originPos = transform.position;

    }

    void FixedUpdate()
    {
        if (!isChestAnim)
        {
            if (archerPlayerStateMachine.curState != null)
            {
                archerPlayerStateMachine.curState.Execute();
            }
        }

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            OnPlayerMonsterCollision?.Invoke();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Chest"))
        {
            isChestAnim = true;
            OnPlayerChestCollision?.Invoke();
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            IsJumping = false;
        }
    }

}
