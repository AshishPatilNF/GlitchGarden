using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    ResourceDefender defender;

    StartsDisplay starsDisplay;

    LevelLoader levelLoading;

    List<Vector2> gridOccupancy = new List<Vector2>();

    private void Start()
    {
        levelLoading = FindObjectOfType<LevelLoader>();
        starsDisplay = FindObjectOfType<StartsDisplay>();
    }

    private void OnMouseDown()
    {
        if (!IsOccupied() && defender && starsDisplay.HasEnoughStars(defender.GetDefenderCost()))
        {
            starsDisplay.SpendStars(defender.GetDefenderCost());
            GameObject newDefender = Instantiate(defender.gameObject, GetSquareClicked(), Quaternion.identity);
            newDefender.transform.parent = levelLoading.GetCleanUpContainer();
            gridOccupancy.Add(newDefender.transform.position);
        }
    }

    private bool IsOccupied()
    {
        // Can be replaced by enabling box colliders on Defenders
        foreach(Vector2 grid in gridOccupancy)
        {
            if(grid.Equals(GetSquareClicked()))
            {
                return true;
            }
        }
        return false;
    }

    public void SetSelectedDefender(ResourceDefender slectedDefender)
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
