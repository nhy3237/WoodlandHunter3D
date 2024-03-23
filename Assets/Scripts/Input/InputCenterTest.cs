using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenterTest : MonoBehaviour
{
    [SerializeField]
    private PlayerType selectedPlayerType;
    [SerializeField]
    private InputHandler inputHandler;

    private IPlayerController playerController;

    void Start()
    {
        playerController = new AiraPlayerController();

        GameManager.instance.OnPlayerTypeChanged += UpdatePlayerType;
        
        inputHandler.OnPlayerWalkInput += ChangeWalkState;
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerJumpInput += ChangeJumpState;

    }

    void OnDestroy()
    {
        GameManager.instance.OnPlayerTypeChanged -= UpdatePlayerType;    
    }

    private void UpdatePlayerType(PlayerType playerType)
    {
        selectedPlayerType = playerType;

        switch (selectedPlayerType)
        {
            case PlayerType.Aira:
                playerController = new AiraPlayerController();

                Debug.Log("AiraPlayerController·Î º¯°æ");
                break;
            case PlayerType.Vian:
                // playerController = new VianPlayerController();
                break;
        }
    }

    void ChangeIdleState()
    {
        playerController.ChangeIdleState();
    }

    void ChangeWalkState()
    {
        playerController.ChangeWalkState();
    }

    void ChangeJumpState()
    {
        playerController.ChangeJumpState();
    }
}
