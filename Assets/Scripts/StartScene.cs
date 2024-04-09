using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    private GameObject startText;
    [SerializeField]
    private Animator startDoorAnimator;
    [SerializeField]
    private GameObject startTitle;
    [SerializeField]
    private GameObject startLine;
    [SerializeField]
    private GameObject menuFirstImage;
    [SerializeField]
    private GameObject menuSecondImage;

    bool isKeyPressed = true;

    void Start()
    {
        StartCoroutine(WaitTitleStart());
    }

    void Update()
    {
        if(!isKeyPressed && Input.anyKeyDown)
        {
            isKeyPressed = true;
            StartCoroutine(WaitOpenDoor());
            StartCoroutine(WaitTitleDestory());
            startText.SetActive(false);
            menuFirstImage.SetActive(true);
            menuSecondImage.SetActive(true);
            startLine.SetActive(false);
        }
    }

    IEnumerator ActiveStartText()
    {
        yield return new WaitForSeconds(3f);
        startText.SetActive(true);
        isKeyPressed = false;
    }

    IEnumerator WaitOpenDoor()
    {
        yield return new WaitForSeconds(1f);
        startDoorAnimator.SetTrigger("OpenDoor");
    }

    IEnumerator WaitTitleDestory()
    {
        yield return new WaitForSeconds(3f);
        startTitle.SetActive(false);

    }

    IEnumerator WaitTitleStart()
    {
        yield return new WaitForSeconds(2f);
        startTitle.SetActive(true);
        StartCoroutine(ActiveStartText());
    }

}
