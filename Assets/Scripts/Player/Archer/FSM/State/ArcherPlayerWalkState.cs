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
