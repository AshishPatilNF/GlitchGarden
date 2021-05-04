using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    AttackerSpawner[] attackerSpawners;

    int attackers = 0;

    bool LevelOver = false;

    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("End Level");
        }
    }
}
