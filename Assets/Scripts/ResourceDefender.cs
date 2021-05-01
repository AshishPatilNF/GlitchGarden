using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDefender : MonoBehaviour
{
    [SerializeField]
    int cost = 100;

    StartsDisplay starsDispaly;

    // Start is called before the first frame update
    void Start()
    {
        starsDispaly = FindObjectOfType<StartsDisplay>();
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
}
