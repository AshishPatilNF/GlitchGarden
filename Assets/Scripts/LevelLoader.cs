using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    GameObject cleanUpContainer;

    int currentIndex;

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentIndex == 0)
        {
            LoadStartMenu(4f);
        }
    }

    public void LoadStartMenu(float delay = 1f)
    {
        StartCoroutine(WaitAndLoadLevel(2, delay));
    }

    public void LoadScene(int indexI)
    {
        StartCoroutine(WaitAndLoadLevel(indexI, 1f));
    }
    public void LoadNextScene(float delay = 1f)
    {
        StartCoroutine(WaitAndLoadLevel(currentIndex + 1, delay));
    }

    public void RestartLevel(float delay = 1f)
    {
        StartCoroutine(WaitAndLoadLevel(currentIndex, delay));
    }

    IEnumerator WaitAndLoadLevel(int index,float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public Transform GetCleanUpContainer()
    {
        return cleanUpContainer.transform;
    }
}
