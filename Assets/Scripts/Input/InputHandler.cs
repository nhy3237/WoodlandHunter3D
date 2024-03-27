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
<<<<<<< HEAD
    public event PlayerInputHandle OnPlayerMeleeAttackInput;
    public event PlayerInputHandle OnPlayerRangedAttackReadyInput;
    public event PlayerInputHandle OnPlayerRangedAttackInput;

=======
    public event PlayerInputHandle OnPlayerAttackInput;
>>>>>>> develop

    Vector2 movement;
    public bool isMouseButtonDown = false;

    public Vector2 GetMovement()
    {
        return movement;
    }

    private void Update()
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayerJumpInput?.Invoke();
        }

<<<<<<< HEAD

        if (Input.GetMouseButtonDown(1))
        {
            OnPlayerMeleeAttackInput?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
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


=======
        if(Input.GetMouseButtonDown(0))
        {
            OnPlayerAttackInput?.Invoke();
        }
>>>>>>> develop
    }
}
