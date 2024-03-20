using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum PlayerEnum { Idle, Walk, Run, Jump, Dash, MeleeAttack, RangedAttack, Die }

public class ArcherPlayerStateMachine : MonoBehaviour
{
    [Header("플레이어 컨트롤러")]
    [SerializeField] public ArcherPlayerController playerController;
    [HideInInspector] public ArcherPlayerState curState;

    public Dictionary<PlayerEnum, ArcherPlayerState> playerStateDictionary;

    private void Awake()
    {
        playerStateDictionary = new Dictionary<PlayerEnum, ArcherPlayerState>
        {
            {PlayerEnum.Idle, new ArcherPlayerIdleState(this) },
            {PlayerEnum.Walk, new ArcherPlayerWalkState(this) },
            {PlayerEnum.Jump, new ArcherPlayerJumpState(this) },
            {PlayerEnum.Dash, new ArcherPlayerDashState(this) }
        };

        if (playerStateDictionary.TryGetValue(PlayerEnum.Idle, out ArcherPlayerState newState))
        {
            curState = newState;
            curState.OnStateEnter();
        }
    }

    public void ChangeState(PlayerEnum newStateType)
    {
        if (curState == null)
        {
            return;
        }
        curState.OnStateExit();

        if (playerStateDictionary.TryGetValue(newStateType, out ArcherPlayerState newState))
        {
            newState.OnStateEnter();
            curState = newState;
        }
    }


}
