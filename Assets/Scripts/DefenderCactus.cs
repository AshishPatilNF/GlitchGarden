using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCactus : MonoBehaviour
{
    [SerializeField]
    GameObject zucchini, gun;

    LevelLoader levelLoading;

    AttackerSpawner laneSpawner;

    // Start is called before the first frame update
    void Start()
    {
        levelLoading = FindObjectOfType<LevelLoader>();
        SetAttackerSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if(laneSpawner.transform.childCount <= 0)
        {
            Debug.Log("No Attacker in lane");
        }
        else
        {
            Debug.Log("Attacker in lane");
        }
    }

    private void AttackZucchini()
    {
        GameObject newZucchi = Instantiate(zucchini, gun.transform.position, Quaternion.identity);
        newZucchi.transform.parent = levelLoading.GetCleanUpContainer();
    }

    private void SetAttackerSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            if(Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon)
            {
                laneSpawner = spawner;
            }
        }
    }
}
