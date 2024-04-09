using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingText : MonoBehaviour
{
    public float dotInterval = 0.5f;
    public float loadingTime = 5f;
    public string nextSceneName;

    private Text loadingText;

    private void Start()
    {
        loadingText = GetComponent<Text>();

        StartCoroutine(UpdateText());
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator UpdateText()
    {
        while (true)
        {
            loadingText.text += ".";
            yield return new WaitForSeconds(dotInterval);

            if (loadingText.text.EndsWith("...."))
            {
                loadingText.text = "불러오는 중.";
            }
            else if (loadingText.text.EndsWith("..."))
            {
                loadingText.text = "불러오는 중..";
            }
            else if (loadingText.text.EndsWith(".."))
            {
                loadingText.text = "불러오는 중...";
            }
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(loadingTime);

        SceneManager.LoadScene(nextSceneName);
    }
}
