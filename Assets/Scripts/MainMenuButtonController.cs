using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    [SerializeField]
    private GameObject selectMark;
    [SerializeField]
    private GameObject loadingObject;

    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectMark.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selectMark.SetActive(false);
    }

    public void SceneChange()
    {
        loadingObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
