using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] attackersPrefabs;

    [SerializeField]
    float minSpawnTime = 1, maxsSpawnTime = 6;
    
    bool spawn = true;

    Coroutine spawning;

    // Start is called before the first frame update
    void Start()
    {
        spawning = StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawning()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxsSpawnTime));
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
