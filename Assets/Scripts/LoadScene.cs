using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private float dotInterval = 0.5f;
    [SerializeField]
    private float loadingTime = 5f;
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private Image loadingImage;
    [SerializeField]
    private GameObject loadingTextObject;
    [SerializeField]
    private GameObject loadingIconObject;
    [SerializeField]
    private GameObject StartObject;
    [SerializeField]
    private string[] backgroundSceneNames;

    private void Start()
    {
        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        while (loadingImage.color.a < 1)
        {
            yield return null;
        }

        StartObject.SetActive(false);
        loadingTextObject.SetActive(true);
        loadingIconObject.SetActive(true);
        StartCoroutine(UpdateText());
        StartCoroutine(ChangeScene());
    }

    private IEnumerator UpdateText()
    {
        while (true)
        {
            yield return new WaitForSeconds(dotInterval);

            if (loadingText.text.EndsWith("중..."))
            {
                loadingText.text = "불러오는 중";
            }
            else if (loadingText.text.EndsWith("중"))
            {
                loadingText.text = "불러오는 중.";
            }
            else if (loadingText.text.EndsWith("중."))
            {
                loadingText.text = "불러오는 중..";
            }
            else
            {
                loadingText.text = "불러오는 중...";
            }
        }
    }

    /*private IEnumerator LoadBackgroundScenes()
    {
        foreach (string sceneName in backgroundSceneNames)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        StartCoroutine(ChangeScene());
    }*/

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(loadingTime);
        
        SceneManager.LoadScene(nextSceneName);
    }
}
