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
        player.animator.SetTrigger("Jump");
        Debug.Log("jump state in");
        player.rigid.AddForce(Vector3.up * player.jumpPower, ForceMode.Impulse);

    }

    public void OnStateEnter()
    {
        
    }

    public void OnStateExit()
    {

    }
}
