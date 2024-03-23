using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action<PlayerType> OnPlayerTypeChanged;

    private PlayerType selectedPlayerType;


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

    public void SetPlayerType(PlayerType playerType)
    {
        selectedPlayerType = playerType;
        Debug.Log(playerType + "�� �÷��̾�� ���õǾ����ϴ�.");

        if(OnPlayerTypeChanged != null)
        {
            OnPlayerTypeChanged(selectedPlayerType);
        }
    }
}
