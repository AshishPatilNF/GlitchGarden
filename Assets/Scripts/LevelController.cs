using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject winLabel;

    AttackerSpawner[] attackerSpawners;

    int attackers = 0;

    bool LevelOver = false;

    void Start()
    {
        Time.timeScale = 1;
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

        if (attackers <= 0 && LevelOver)
        {
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 0;
        winLabel.SetActive(true);
    }
}
