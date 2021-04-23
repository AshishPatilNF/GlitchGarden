using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentIndex;

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentIndex == 0)
        {
            StartCoroutine(WaitAndLoadLevel(3.5f));
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(WaitAndLoadLevel());
    }

    IEnumerator WaitAndLoadLevel(float delay = 1)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
