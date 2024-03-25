using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public delegate void PlayerInputHandle();
    public event PlayerInputHandle OnPlayerWalkInput;
    public event PlayerInputHandle OnPlayerRunInput;
    public event PlayerInputHandle OnPlayerIdle;
    public event PlayerInputHandle OnPlayerJumpInput;
    public event PlayerInputHandle OnPlayerMeleeAttackInput;
    public event PlayerInputHandle OnPlayerRangedAttackReadyInput;
    public event PlayerInputHandle OnPlayerRangedAttackInput;


    Vector2 movement;

    public Vector2 GetMovement()
    {
        return movement;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            movement.x = horizontalInput;
            movement.y = verticalInput;

            OnPlayerWalkInput?.Invoke();

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                OnPlayerRunInput?.Invoke();
            }

            if (verticalInput > 0)
            {

            }
        }
        else
        {
            OnPlayerIdle?.Invoke();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            OnPlayerJumpInput?.Invoke();
        }


        if (Input.GetMouseButtonDown(1))
        {
            OnPlayerMeleeAttackInput?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Ranged Attack Ready..");
            OnPlayerRangedAttackReadyInput?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Ranged Attack ");
            OnPlayerRangedAttackInput?.Invoke();
        }

    }
}
