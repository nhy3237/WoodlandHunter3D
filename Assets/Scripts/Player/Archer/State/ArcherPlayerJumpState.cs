using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayerJumpState : ArcherPlayerState
{
    public ArcherPlayerController player { get; set; }
    public ArcherPlayerStateMachine playerStateMachine { get; set; }

    public ArcherPlayerJumpState(ArcherPlayerStateMachine _playerStateMachine)
    {
        playerStateMachine = _playerStateMachine;
        player = playerStateMachine.playerController;
    }

    public void Execute()
    {
        

    }

    public void OnStateEnter()
    {
        Debug.Log("jump state in");

        player.animator.SetTrigger("Jump");
    }

    public void OnStateExit()
    {
        Debug.Log("jump state out");

        player.ISJUMPING = false;
    }
}
