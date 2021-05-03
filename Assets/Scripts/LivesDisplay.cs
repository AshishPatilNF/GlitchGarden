using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    int Lives = 99;

    TextMeshProUGUI text;

    LevelLoader level;

    private void Start()
    {
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
        DisplayLives();
        if(Lives <= 0)
        {
            Lives = 0;
            level.LoadScene(1);
        }
    }
}
