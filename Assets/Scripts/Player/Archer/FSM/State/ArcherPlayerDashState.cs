using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlayerDashState : ArcherPlayerState
{
    public ArcherPlayerController player { get; set; }
    public ArcherPlayerStateMachine playerStateMachine { get; set; }

    public ArcherPlayerDashState(ArcherPlayerStateMachine _playerStateMachine)
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
