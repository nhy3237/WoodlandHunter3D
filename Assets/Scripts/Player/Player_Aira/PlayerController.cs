using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("move Speed")]
    public float moveSpeed = 1f;

    private float currentHorizontal = 0f;
    private float currentVertical = 0f;

    private StateMachine<PlayerController> stateMachine;
    private Animator animator;

    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();

        stateMachine = new StateMachine<PlayerController>();
        stateMachine.Setup(this, new AiraIdleState(animator));
    }

    private void Update()
    {
        //stateMachine.Execute();
    }
}
