using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] attackersPrefabs;

    [SerializeField]
    float minSpawnTime = 1, maxSpawnTime = 6;
    
    bool spawn = true;

    Coroutine spawning;

    void Start()
    {
        spawning = StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            Debug.Log(this.gameObject.name + "-" + Time.time);
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        GameObject newAttacker = Instantiate(attackersPrefabs[Random.Range(0, attackersPrefabs.Length)], transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        spawn = false;
        StopCoroutine(spawning);
    }
}
