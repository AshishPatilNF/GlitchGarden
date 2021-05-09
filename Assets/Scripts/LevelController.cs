using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject winLabel;

    AttackerSpawner[] attackerSpawners;

    LivesDisplay livesDisplay;

    int attackers = 0;

    bool LevelOver = false;

    void Start()
    {
        Time.timeScale = 1;
        livesDisplay = FindObjectOfType<LivesDisplay>();
        winLabel.SetActive(false);
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();
    }

    public void FinishLevelSpawning()
    {
        LevelOver = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        foreach(AttackerSpawner spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }

    public void AddAttackers()
    {
        attackers++;
    }

    public void RemoveAttackers()
    {
        attackers--;

        if (attackers <= 0 && LevelOver && livesDisplay.GetLives() > 0)
        {
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 0;
        winLabel.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex == 7)
            FindObjectOfType<LevelLoader>().LoadNextScene(3);
    }
}
