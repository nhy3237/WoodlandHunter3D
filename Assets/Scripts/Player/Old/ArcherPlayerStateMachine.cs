//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Playables;

//public enum ArcherPlayerEnum { Idle, Walk, Run, Jump, MeleeAttack, RangedAttack, Die }

//public class ArcherPlayerStateMachine : MonoBehaviour
//{
//    [Header("플레이어 컨트롤러")]
//    [SerializeField] public ArcherPlayerController playerController;
//    [HideInInspector] public ArcherPlayerState curState;

//    public Dictionary<ArcherPlayerEnum, ArcherPlayerState> playerStateDictionary;

//    private void Awake()
//    {
//        playerStateDictionary = new Dictionary<ArcherPlayerEnum, ArcherPlayerState>
//        {
//            {ArcherPlayerEnum.Idle, new ArcherPlayerIdleState(this) },
//            {ArcherPlayerEnum.Walk, new ArcherPlayerWalkState(this) },
//            {ArcherPlayerEnum.Jump, new ArcherPlayerJumpState(this) }
//        };

//        if (playerStateDictionary.TryGetValue(ArcherPlayerEnum.Idle, out ArcherPlayerState newState))
//        {
//            curState = newState;
//            curState.OnStateEnter();
//        }
//    }

//    public void ChangeState(ArcherPlayerEnum newStateType)
//    {
//        if (curState == null)
//        {
//            return;
//        }
//        curState.OnStateExit();

//        if (playerStateDictionary.TryGetValue(newStateType, out ArcherPlayerState newState))
//        {
//            newState.OnStateEnter();
//            curState = newState;
//        }
//    }


//}
