using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action OnPlayerObjectChanged;

    private GameObject selectedPlayerObject;
    private IPlayerController playerController;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            if (playerObject.activeSelf)
            {
                SetPlayerType(playerObject);
                break;
            }
        }
    }

    public void SetPlayerType(GameObject playerObject)
    {
        if (selectedPlayerObject != null)
        {
            selectedPlayerObject.SetActive(false);
        }
        selectedPlayerObject = playerObject;
        selectedPlayerObject.SetActive(true);

        playerController = selectedPlayerObject.GetComponentInChildren<IPlayerController>();

        if(OnPlayerObjectChanged != null)
        {
            OnPlayerObjectChanged();
        }

        Debug.Log(selectedPlayerObject + "가 플레이어로 선택되었습니다.");
    }

    public IPlayerController GetPlayerController()
    {
        return playerController;
    }
}
