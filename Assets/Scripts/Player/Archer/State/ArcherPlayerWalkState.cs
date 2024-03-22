using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayerWalkState : ArcherPlayerState
{
    public ArcherPlayerController player { get; set; }
    public ArcherPlayerStateMachine playerStateMachine { get; set; }

    public ArcherPlayerWalkState(ArcherPlayerStateMachine _playerStateMachine)
    {
        playerStateMachine = _playerStateMachine;
        player = playerStateMachine.playerController;
    }

    Vector2 movement;

    public void OnStateEnter()
    {
        player.animator.SetBool("IsWalking", true);
    }

    public void Execute()
    {
        movement.x = player.animator.GetFloat("XDir");
        movement.y = player.animator.GetFloat("YDir");



    }

    public void OnStateExit()
    {
        player.animator.SetBool("IsWalking", false);
    }
}
