using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTypeSelector : MonoBehaviour
{
    public Button AiraPlayerButton;
    public Button VianPlayerButton;

    void Start()
    {
        AiraPlayerButton.onClick.AddListener(SelectAira);
        VianPlayerButton.onClick.AddListener(SelectVian);
    }

    public void SelectAira()
    {
        GameManager.instance.SetPlayerType(PlayerType.Aira);
    }

    public void SelectVian()
    {
        GameManager.instance.SetPlayerType(PlayerType.Vian);
    }
}
