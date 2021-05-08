using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    float damage = 8;

    int multiplier;

    private void Start()
    {
        multiplier = PlayerPrefsController.GetDifficulty();
        damage *= Random.Range(multiplier, multiplier * 1.7f);
    }

    public float GetDamage()
    {
        return damage;
    }
}
