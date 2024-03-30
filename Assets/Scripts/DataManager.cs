using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] playerObjects;
    private GameObject playerObject;

    void Start()
    {
        
    }

    public GameObject GetPlayerObject()
    {
        if (playerObject == null)
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
            this.playerObject = Instantiate(playerObjects[0]);
        }

        this.playerObject.transform.position = new Vector3(0, 0, 0);
        }

        return playerObject;
    }
}
