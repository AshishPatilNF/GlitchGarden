using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject defenderPrefab;

    private void OnMouseDown()
    {
        Instantiate(defenderPrefab, GetSquareClicked(), Quaternion.identity);
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }
}
