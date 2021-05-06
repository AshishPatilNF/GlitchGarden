using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Timer in Seconds")]
    [SerializeField]
    float levelTime = 10;

    Slider slider;

    LevelController levelControll;

    bool levelDone = false;

    void Start()
    {
        levelControll = FindObjectOfType<LevelController>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if(levelDone)
        {
            return;
        }

        slider.value = Time.timeSinceLevelLoad / levelTime;

        if(Time.timeSinceLevelLoad >= levelTime)
        {
            levelControll.FinishLevelSpawning();
            levelDone = true;
        }
    }
}
