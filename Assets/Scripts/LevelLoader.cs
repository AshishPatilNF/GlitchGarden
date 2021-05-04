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
            LoadNextScene(3.5f);
        }
    }

    public void LoadScene(int index, float delay = 1f)
    {
        StartCoroutine(WaitAndLoadLevel(index, delay));
    }

    public void LoadNextScene(float delay = 1f)
    {
        StartCoroutine(WaitAndLoadLevel(currentIndex + 1, delay));
    }

    IEnumerator WaitAndLoadLevel(int index,float delay)
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
