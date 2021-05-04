using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject winLabel;

    AttackerSpawner[] attackerSpawners;

    LevelLoader levelLoad;

    int attackers = 0;

    bool LevelOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        levelLoad = FindObjectOfType<LevelLoader>();
        winLabel.SetActive(false);
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();
    }

    // Update is called once per frame
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
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 0;
        winLabel.SetActive(true);
    }
}
