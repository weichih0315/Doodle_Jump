using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;

    public Text masterVolumeText;
    public Text musicVolumeText;
    public Text sfxVolumeText;

    public Slider[] volumeSliders;

	void Start() {
		volumeSliders [0].value = AudioManager.instance.masterVolumePercent;
		volumeSliders [1].value = AudioManager.instance.musicVolumePercent;
		volumeSliders [2].value = AudioManager.instance.sfxVolumePercent;

        masterVolumeText.text = (int)(volumeSliders[0].value * 100) + "";
        musicVolumeText.text = (int)(volumeSliders[1].value * 100) + "";
        sfxVolumeText.text = (int)(volumeSliders[2].value * 100) + "";

    }
    
	public void Play() {
		SceneManager.LoadScene ("Game");
	}

    public void Quit() {
		Application.Quit ();
	}

	public void OptionsMenu() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);
	}

	public void MainMenu() {
		mainMenuHolder.SetActive (true);
		optionsMenuHolder.SetActive (false);
	}

	

	public void SetMasterVolume(float value) {
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Master);
        masterVolumeText.text = (int)(value * 100) + "";
    }

	public void SetMusicVolume(float value) {
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Music);
        musicVolumeText.text = (int)(value * 100) + "";
    }

	public void SetSfxVolume(float value) {
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Sfx);
        sfxVolumeText.text = (int)(value * 100) + "";
    }

}
