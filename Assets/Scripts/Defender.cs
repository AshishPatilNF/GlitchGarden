using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField]
    GameObject zucchini, gun;

    LevelLoader levelLoading;

    // Start is called before the first frame update
    void Start()
    {
        levelLoading = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AttackZucchini()
    {
        GameObject newZucchi = Instantiate(zucchini, gun.transform.position, Quaternion.identity);
        newZucchi.transform.parent = levelLoading.GetCleanUpContainer();
    }
}
