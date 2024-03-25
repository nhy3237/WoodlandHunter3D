using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VianPlayerIdleState : State<VianPlayerController>
{
    private Animator animator;

    public VianPlayerIdleState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(VianPlayerController entity)
    {
        
    }

    public override void Execute(VianPlayerController entity)
    {

    }

    public override  void Exit(VianPlayerController entity)
    {
    }
}
