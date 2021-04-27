using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab;

    LevelLoader levelLoading;

    private void Start()
    {
        levelLoading = FindObjectOfType<LevelLoader>();
    }

    private void OnMouseDown()
    {
        if(defenderPrefab)
        {
            GameObject newCactus = Instantiate(defenderPrefab.gameObject, GetSquareClicked(), Quaternion.identity);
            newCactus.transform.parent = levelLoading.GetCleanUpContainer();
        }
    }

    public void SetSelectedDefender(Defender slectedDefender)
    {
        defenderPrefab = slectedDefender;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        return gridPos;
    }
}
