using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    AttackerSpawner[] attackerSpawners;

    GameTimer gameTimer;

    List<GameObject> attackers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        gameTimer = FindObjectOfType<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameTimer.IsLevelOver())
        {
            StopSpawners();
        }

        if (attackers.Count == 0 && gameTimer.IsLevelOver())
        {
            Debug.Log("End Level");
        }
    }

    private void StopSpawners()
    {
        foreach(AttackerSpawner spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }

    public void AddAttackers(GameObject attacker)
    {
        attackers.Add(attacker);
    }

    public void RemoveAttackers(GameObject attacker)
    {
        attackers.Remove(attacker);
    }
}
