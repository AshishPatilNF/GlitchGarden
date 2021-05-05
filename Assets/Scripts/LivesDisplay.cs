using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject looseLabel;

    int Lives = 10;

    TextMeshProUGUI text;

    LevelLoader level;

    private void Start()
    {
        looseLabel.SetActive(false);
        level = FindObjectOfType<LevelLoader>();
        text = GetComponent<TextMeshProUGUI>();
        DisplayLives();
    }

    private void DisplayLives()
    {
        text.text = Lives.ToString();
    }

    public void ReduceLive()
    {
        Lives--;
        if(Lives < 0)
        {
            Lives = 0;
        }
        DisplayLives();
        if(Lives <= 0)
        {
            Time.timeScale = 0;
            looseLabel.SetActive(true);
        }
    }
}
