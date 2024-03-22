using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayerIdleState : ArcherPlayerState
{
    public ArcherPlayerController player { get; set; }
    public ArcherPlayerStateMachine playerStateMachine { get; set; }

    public ArcherPlayerIdleState(ArcherPlayerStateMachine _playerStateMachine)
    {
        playerStateMachine = _playerStateMachine;
        player = playerStateMachine.playerController;
    }

    public void Execute()
    {

    }

    public void OnStateEnter()
    {

    }

    public void OnStateExit()
    {

    }
}
