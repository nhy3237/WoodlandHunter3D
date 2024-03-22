using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayerIdleState : State<ArcherPlayerController>
{
    private Animator animator;

    public ArcherPlayerIdleState(Animator animator)
    {
        this.animator = animator;
    }

    public override void Enter(ArcherPlayerController entity)
    {
        
    }

    public override void Execute(ArcherPlayerController entity)
    {

    }

    public override  void Exit(ArcherPlayerController entity)
    {
    }
}
