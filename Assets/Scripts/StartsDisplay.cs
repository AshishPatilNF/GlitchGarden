using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartsDisplay : MonoBehaviour
{
    float stars = 100;

    int starCount;

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

    public void AddStars(float amount)
    {
        amount -= 0.5f * starCount;
        stars += (int)(amount);
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

    public void AddStarCount()
    {
        starCount++;
    }

    public void ReduceStarCount()
    {
        starCount--;
    }
}
