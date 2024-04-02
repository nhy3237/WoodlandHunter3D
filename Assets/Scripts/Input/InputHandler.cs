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

    public event PlayerInputHandle OnPlayerAttackInput;

    Vector3 movement;
    public bool isMouseButtonDown = false;

    public Vector3 GetMovement()
    {
        return movement;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            movement.x = horizontalInput;
            movement.z = verticalInput;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayerJumpInput?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnPlayerMeleeAttackInput?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            // aria
            OnPlayerAttackInput?.Invoke();

            // vian
            Debug.Log("Ranged Attack Ready..");
            isMouseButtonDown = true;
            OnPlayerRangedAttackReadyInput?.Invoke();
        }

        if (isMouseButtonDown && !Input.GetMouseButton(0))
        {

            isMouseButtonDown = false;
            Debug.Log("Ranged Attack ");
            OnPlayerRangedAttackInput?.Invoke();
        }

    }
}
