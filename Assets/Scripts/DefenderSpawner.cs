using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject defenderPrefab;

    LevelLoader levelLoading;

    private void Start()
    {
        levelLoading = FindObjectOfType<LevelLoader>();
    }

    private void OnMouseDown()
    {
        GameObject newCactus = Instantiate(defenderPrefab, GetSquareClicked(), Quaternion.identity);
        newCactus.transform.parent = levelLoading.GetCleanUpContainer();
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        return gridPos;
    }
}
