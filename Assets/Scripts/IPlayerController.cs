using UnityEngine;

public interface IPlayerController
{
    void ChangeIdleState();
    void ChangeWalkState(Vector3 movement);
    void ChangeRunState();
    void ChangeJumpState();
    void ChangeAttackState();
    void ChangeMeleeAttackState();
}
