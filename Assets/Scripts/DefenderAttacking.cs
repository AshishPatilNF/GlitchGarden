using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttacking : MonoBehaviour
{
    [SerializeField]
    GameObject projectile, gun;

    [SerializeField]
    bool laner = false;

    LevelLoader levelLoading;

    AttackerSpawner laneSpawner;

    AttackerSpawner[] spawners; 

    Animator animator;

    DefenderSpawner defenderSpawner;

    // Start is called before the first frame update
    void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        spawners = FindObjectsOfType<AttackerSpawner>();
        levelLoading = FindObjectOfType<LevelLoader>();
        animator = GetComponent<Animator>();
        SetAttackerSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if(laner)
        {
            Lanning();
        }

        if(laneSpawner.transform.childCount <= 0)
        {
            animator.SetBool("isIdel", true);
        }
        else
        {
            animator.SetBool("isIdel", false);
        }
    }

    private void AttackProjectile()
    {
        GameObject newZucchi = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newZucchi.transform.parent = levelLoading.GetCleanUpContainer();
    }

    private void SetAttackerSpawner()
    {
        foreach (AttackerSpawner spawner in spawners)
        {
            if(Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon)
            {
                laneSpawner = spawner;
            }
        }
    }

    private void Lanning()
    {
        if(laneSpawner.transform.childCount <= 0 || GetChildPosition(laneSpawner.transform.GetComponentsInChildren<Attacker>()))
        {
            foreach(AttackerSpawner spawner in spawners)
            {
                if(spawner.transform.childCount > 0 && !defenderSpawner.IsOccupied(new Vector2(transform.position.x, spawner.transform.position.y)))
                {
                    defenderSpawner.RemoveGridOccupancy(transform.position);
                    laneSpawner = spawner;
                    transform.position = new Vector2(transform.position.x, spawner.transform.position.y);
                    defenderSpawner.AddGridOccupancy(transform.position);
                }
            }
        }
    }

    private bool GetChildPosition(Attacker[] attackers)
    {
        foreach(Attacker attacker in attackers)
        {
            if(attacker.transform.position.x <= transform.position.x)
            {
                return true;
            }
        }
        return false;
    }
}
