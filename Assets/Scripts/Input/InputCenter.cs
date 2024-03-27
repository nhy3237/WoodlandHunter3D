using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    [SerializeField]
    private PlayerType selectedPlayerType;
    [SerializeField]
    private InputHandler inputHandler;
    [SerializeField]
    private GameObject[] playerObjects;

    private IPlayerController playerController;

    private GameObject player;

    void Start()
    { 
        if(GameManager.instance.GetPlayerTag() != null)
        {
            foreach (GameObject playerObject in playerObjects)
            {
                if (playerObject.transform.CompareTag(GameManager.instance.GetPlayerTag()))
                {
                    player = Instantiate(playerObject);
                }
            }
        }
        else // test
        {
            player = Instantiate(playerObjects[0]);
        }

        player.transform.position = new Vector3(0, 0, 0);

        playerController = player.GetComponentInChildren<IPlayerController>();

        inputHandler.OnPlayerWalkInput += ChangeWalkState;
        inputHandler.OnPlayerIdle += ChangeIdleState;
        inputHandler.OnPlayerJumpInput += ChangeJumpState;
        inputHandler.OnPlayerAttackInput += ChangeAttackState;
    }

    void OnDestroy()
    {
    }

    void ChangeIdleState()
    {
        playerController?.ChangeIdleState();
    }

    void ChangeWalkState()
    {
        playerController?.ChangeWalkState(inputHandler.GetMovement());
    }

    void ChangeJumpState()
    {
        playerController?.ChangeJumpState();
    }

    void ChangeAttackState()
    {
        playerController?.ChangeAttackState();
    }
}
