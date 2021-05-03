using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderResource : MonoBehaviour
{
    [SerializeField]
    int health = 100;

    [SerializeField]
    int cost = 100;

    [SerializeField]
    GameObject deathVFX;

    StartsDisplay starsDispaly;

    LevelLoader levelLoad;

    DefenderSpawner defenderSpawner;

    // Start is called before the first frame update
    void Start()
    {
        levelLoad = FindObjectOfType<LevelLoader>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        starsDispaly = FindObjectOfType<StartsDisplay>();
        defenderSpawner.AddGridOccupancy(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddStars(int amount)
    {
        starsDispaly.AddStars(amount);
    }

    public int GetDefenderCost()
    {
        return cost;
    }

    public void DamageHealth(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            GameObject newVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
            newVFX.transform.parent = levelLoad.GetCleanUpContainer();
            Destroy(newVFX, 1f);
            defenderSpawner.RemoveGridOccupancy(transform.position);
            Destroy(this.gameObject);
        }
    }
}
