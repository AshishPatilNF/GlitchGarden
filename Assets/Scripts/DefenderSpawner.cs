using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    StartsDisplay starsDisplay;

    LevelLoader levelLoading;

    private void Start()
    {
        levelLoading = FindObjectOfType<LevelLoader>();
        starsDisplay = FindObjectOfType<StartsDisplay>();
    }

    private void OnMouseDown()
    {
        if(defender && starsDisplay.HasEnoughStars(defender.GetDefenderCost()))
        {
            starsDisplay.SpendStars(defender.GetDefenderCost());
            GameObject newDefender = Instantiate(defender.gameObject, GetSquareClicked(), Quaternion.identity);
            newDefender.transform.parent = levelLoading.GetCleanUpContainer();
        }
    }

    public void SetSelectedDefender(Defender slectedDefender)
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
