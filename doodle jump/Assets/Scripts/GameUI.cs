using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Space(10)]
    [Header("score")]
    public Text scoreUI;

    [Space(10)]
    [Header("option")]
    public GameObject optionsMenuHolder;

    public Text masterVolumeText;
    public Text musicVolumeText;
    public Text sfxVolumeText;

    public Slider[] volumeSliders;

    [Space(10)]
    [Header("gameover")]
    public GameObject gameoverUIHolder;


    private Player player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnDeath += GameOver;

        volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders[2].value = AudioManager.instance.sfxVolumePercent;

        masterVolumeText.text = (int)(volumeSliders[0].value * 100) + "";
        musicVolumeText.text = (int)(volumeSliders[1].value * 100) + "";
        sfxVolumeText.text = (int)(volumeSliders[2].value * 100) + "";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            scoreUI.text = ScoreKeeper.score.ToString("D6");            //分數顯示  6位10進制
        }
    }

    public void GameOver()
    {
        gameoverUIHolder.SetActive(true);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            optionsMenuHolder.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            optionsMenuHolder.SetActive(false);
        }
    }

    public void Again()
    {
        SceneManager.LoadScene("Game");
    }

    public void SetMasterVolume(int value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
        masterVolumeText.text = (int)(value * 100) + "";
    }

    public void SetMusicVolume(int value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
        musicVolumeText.text = (int)(value * 100) + "";
    }

    public void SetSfxVolume(int value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
        sfxVolumeText.text = (int)(value * 100) + "";
    }
}