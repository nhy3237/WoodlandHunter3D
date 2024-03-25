using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTypeSelector : MonoBehaviour
{
    public Button AiraPlayerButton;
    public GameObject AiraPlayer;

    public Button VianPlayerButton;
    public GameObject VianPlayer;

    void Start()
    {
        AiraPlayerButton.onClick.AddListener(SelectAira);
        VianPlayerButton.onClick.AddListener(SelectVian);
    }

    public void SelectAira()
    {
        GameManager.instance.SetPlayerType(AiraPlayer);
    }

    public void SelectVian()
    {
        GameManager.instance.SetPlayerType(VianPlayer);
    }
}
