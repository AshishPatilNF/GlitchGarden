using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartsDisplay : MonoBehaviour
{
    [SerializeField]
    int stars = 100;

    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        UpdateStars();
    }

    private void UpdateStars()
    {
        text.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateStars();
    }

    public void SpendStars(int amount)
    {
        if(stars >= amount)
        {
            stars -= amount;
            UpdateStars();
        }
    }

    public bool HasEnoughStars(int amount)
    {
        return stars >= amount;
    }
}
