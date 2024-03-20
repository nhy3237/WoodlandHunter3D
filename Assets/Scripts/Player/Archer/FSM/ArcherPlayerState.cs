using UnityEngine;
using System.Collections;

public interface ArcherPlayerState
{
    ArcherPlayerController player { get; set; }
    ArcherPlayerStateMachine playerStateMachine { get; set; }

    void Execute();
    void OnStateEnter();
    void OnStateExit();
}

