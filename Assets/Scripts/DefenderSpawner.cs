using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    DefenderResource defender;

    StartsDisplay starsDisplay;

    GameObject defendersSpawned;

    List<Vector2> gridOccupancy = new List<Vector2>();

    private void Start()
    {
        defendersSpawned = GameObject.Find("Defenders");
        if (!defendersSpawned)
            defendersSpawned = new GameObject("Defenders");
        starsDisplay = FindObjectOfType<StartsDisplay>();
    }

    private void OnMouseDown()
    {
        if (!IsOccupied(GetSquareClicked()) && defender && starsDisplay.HasEnoughStars(defender.GetDefenderCost()))
        {
            starsDisplay.SpendStars(defender.GetDefenderCost());
            GameObject newDefender = Instantiate(defender.gameObject, GetSquareClicked(), Quaternion.identity);
            newDefender.transform.parent = defendersSpawned.transform;
        }
    }

    public void AddGridOccupancy(Vector2 gridOccu)
    {
        gridOccupancy.Add(gridOccu);
    }

    public void RemoveGridOccupancy(Vector2 gridOccu)
    {
        gridOccupancy.Remove(gridOccu);
    }

    public bool IsOccupied(Vector2 tryGrid)
    {
        // Can be replaced by enabling box colliders on Defenders
        foreach(Vector2 grid in gridOccupancy)
        {
            if(grid.Equals(tryGrid))
            {
                return true;
            }
        }
        return false;
    }

    public void SetSelectedDefender(DefenderResource slectedDefender)
    {
        defender = slectedDefender;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        return gridPos;
    }
}
