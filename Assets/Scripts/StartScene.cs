using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField] GameObject startText;
    [SerializeField] Animator startDoorAnimator;
    [SerializeField] GameObject startTitle;
    [SerializeField] GameObject startLine;

    bool isKeyPressed = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActiveStartText());
    }

    // Update is called once per frame
    void Update()
    {
        if(!isKeyPressed && Input.anyKeyDown)
        {
            isKeyPressed = true;
            StartCoroutine(WaitOpenDoor());
            StartCoroutine(WaitTitleDestory());
            startText.SetActive(false);
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

}
