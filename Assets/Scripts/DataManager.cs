using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] playerObjects;
    private GameObject playerObject;

    void Awake()
    {
        if (GameManager.instance.GetPlayerTag() != null)
        {
            foreach (GameObject playerObject in playerObjects)
            {
                if (playerObject.transform.CompareTag(GameManager.instance.GetPlayerTag()))
                {
                    this.playerObject = Instantiate(playerObject);
                }
            }
        }
        else // test
        {
            playerObject = Instantiate(playerObjects[0]);
        }

        playerObject.transform.position = new Vector3(0, 0, 0);
    }

    public GameObject GetPlayerObject()
    {
        return playerObject;
    }
}
