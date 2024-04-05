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

    private string selectedPlayerTag;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    public void SetPlayerType(GameObject playerObject)
    {
        selectedPlayerObject = playerObject;

        selectedPlayerTag = selectedPlayerObject.tag;

        if(OnPlayerObjectChanged != null)
        {
            OnPlayerObjectChanged();
        }

        Debug.Log(selectedPlayerObject + "SELECT!!!!");
    }

    public IPlayerController GetPlayerController()
    {
        return playerController;
    }

    public string GetPlayerTag()
    {
        return selectedPlayerTag;
    }
}
