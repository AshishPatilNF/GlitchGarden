using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] 
    Slider volumeSlider;

    [SerializeField]
    Slider difficultySlider;

    float defaultVolume = 0.8f;

    int defaultDifficulty = 1;

    MusicPlayer musicPlayer;

    LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);
        levelLoader.LoadStartMenu();
    }

    public void DefaultOptions()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
