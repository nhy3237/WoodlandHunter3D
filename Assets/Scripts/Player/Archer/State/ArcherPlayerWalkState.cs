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

    Vector3 movement;

    public void OnStateEnter()
    {
        Debug.Log("state in");
        player.animator.SetBool("IsWalking", true);
    }

    public void Execute()
    {
        movement.x = player.animator.GetFloat("XDir");
        movement.z = player.animator.GetFloat("YDir");

        Debug.Log("move " + movement * player.speed * Time.deltaTime);
        player.transform.Translate(movement * player.speed * Time.deltaTime);

    }

    public void OnStateExit()
    {
        player.animator.SetBool("IsWalking", false);
    }
}
