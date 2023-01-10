using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public Image image1;
    public TextMeshProUGUI text1;
    public Image image2;
    public TextMeshProUGUI text2;
    public Image image3;
    public TextMeshProUGUI text3;

    public GameObject loadingScreen;
    public Slider loadingBar;

    public float timeBetweenElements = 1.0f;

    void Start()
    {
        StartCoroutine(ShowIntroSequence());
    }

    IEnumerator ShowIntroSequence()
    {
        // Show the first image and text
        image1.gameObject.SetActive(true);
        text1.gameObject.SetActive(true);

        // Wait for the specified amount of time
        yield return new WaitForSeconds(timeBetweenElements);

        // Hide the first image and text and show the second image and text
        image1.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        image2.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);

        // Wait for the specified amount of time
        yield return new WaitForSeconds(timeBetweenElements);

        // Hide the second image and text and show the third image and text
        image2.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        image3.gameObject.SetActive(true);
        text3.gameObject.SetActive(true);

        // Wait for the specified amount of time
        yield return new WaitForSeconds(timeBetweenElements);

        // Hide the third image and text and load the first level
        image3.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);

        LoadScene(1);
    }


    public void LoadScene(int levelIndex)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadScenesAsynchronously(levelIndex));
    }

    IEnumerator LoadScenesAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }



}