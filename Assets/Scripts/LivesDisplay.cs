using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject looseLabel;

    int Lives = 5;

    TextMeshProUGUI text;

    private void Start()
    {
        if (PlayerPrefsController.GetDifficulty() < 3)
            Lives = 3;
        else
            Lives = 2;
        looseLabel.SetActive(false);
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

    public int GetLives()
    {
        return Lives;
    }
}
