using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    GameObject LoadingScreenObject;
    [SerializeField]
    Image LoadingBar;

    public void StartApp()
    {
        SceneManager.LoadScene("2D",LoadSceneMode.Additive);
    }
    public void StartApp2()
    {
        SceneManager.LoadScene("2D", LoadSceneMode.Single);
    }
    public void StartApp3()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void StartApp4()
    {
        SceneManager.LoadSceneAsync("2D 1");
        GlobalInformation.AllCoinsOnMap = 0;
        GlobalInformation.CollectedCoins = 0;

    }
    public void StartApp5(int SceneIndex)
    {
        StartCoroutine(LoadingScreen(SceneIndex));
    }

    public IEnumerator LoadingScreen(int SceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingScreenObject.SetActive(true);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 2f) ;

            LoadingBar.fillAmount = progress ;

            yield return null;
        }
          
    }
}
