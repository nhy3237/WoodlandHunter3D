using UnityEngine;

public interface IPlayerController
{
    void ChangeIdleState();
    void ChangeWalkState(Vector3 movement);
    void ChangeJumpState();
    void ChangeAttackState();
}
