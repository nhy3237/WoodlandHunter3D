using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTypeSelector : MonoBehaviour
{
    public Button AiraPlayerButton;
    public Button VianPlayerButton;
    public Button NextButton;
    
    public GameObject AiraPlayer;
    public GameObject VianPlayer;

    public Image CheckMarkImage;

    void Start()
    {
        AiraPlayerButton.onClick.AddListener(SelectAira);
        VianPlayerButton.onClick.AddListener(SelectVian);
        NextButton.onClick.AddListener(ChangeScene);
        GameManager.instance.SetPlayerType(AiraPlayer);
    }

    public void SelectAira()
    {
        GameManager.instance.SetPlayerType(AiraPlayer);
        CheckMarkImage.rectTransform.anchoredPosition = new Vector2(-440f, CheckMarkImage.rectTransform.anchoredPosition.y);
    }

    public void SelectVian()
    {
        GameManager.instance.SetPlayerType(VianPlayer);
        CheckMarkImage.rectTransform.anchoredPosition = new Vector2(243f, CheckMarkImage.rectTransform.anchoredPosition.y);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("01.Village");
    }
}
