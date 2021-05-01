using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingDefender : MonoBehaviour
{
    [SerializeField]
    GameObject projectile, gun;

    LevelLoader levelLoading;

    AttackerSpawner laneSpawner;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        levelLoading = FindObjectOfType<LevelLoader>();
        animator = GetComponent<Animator>();
        SetAttackerSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if(laneSpawner.transform.childCount <= 0)
        {
            animator.SetBool("isIdel", true);
        }
        else
        {
            animator.SetBool("isIdel", false);
        }
    }

    private void AttackZucchini()
    {
        GameObject newZucchi = Instantiate(projectile, gun.transform.position, Quaternion.identity);
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
