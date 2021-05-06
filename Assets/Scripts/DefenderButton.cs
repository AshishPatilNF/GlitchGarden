using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField]
    DefenderResource defendPrefab;

    DefenderSpawner defendSpawn;

    DefenderButton[] defenders;

    private void Start()
    {
        defendSpawn = FindObjectOfType<DefenderSpawner>();
        defenders = FindObjectsOfType<DefenderButton>();
        GetComponentInChildren<TextMeshProUGUI>().text = defendPrefab.GetDefenderCost().ToString();
    }

    private void OnMouseDown()
    {
        foreach (DefenderButton defender in defenders)
        {
            defender.GetComponent<SpriteRenderer>().color = new Color32(111, 108, 108, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        defendSpawn.SetSelectedDefender(defendPrefab);
    }
}
