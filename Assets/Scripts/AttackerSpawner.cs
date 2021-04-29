using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject attackerPrefab;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            SpawnAttacker();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAttacker()
    {
        GameObject newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}
