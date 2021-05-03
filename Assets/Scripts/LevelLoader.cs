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
            StartCoroutine(WaitAndLoadLevel(currentIndex + 1, 3.5f));
        }
    }

    public void LoadScene(int index)
    {
        StartCoroutine(WaitAndLoadLevel(index));
    }

    public void LoadNextScene()
    {
        StartCoroutine(WaitAndLoadLevel(currentIndex + 1));
    }

    IEnumerator WaitAndLoadLevel(int index, float delay = 1)
    {
        yield return new WaitForSeconds(delay);
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
