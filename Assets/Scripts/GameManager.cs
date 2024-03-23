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
        Debug.Log(playerType + "가 플레이어로 선택되었습니다.");

        if(OnPlayerTypeChanged != null)
        {
            OnPlayerTypeChanged(selectedPlayerType);
        }
    }
}
