using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class Menu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject MainMenu;
    public Slider MenuSoundSlider;
    AudioSource audioSource;

    float vol = 0.5f;
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        MenuSoundSlider.value = vol;
    }
    public void Update()
    {
        audioSource.volume = vol;
    }
    public void StarGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenSettingsMenu()
    {
        MainMenu.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void BackButton()
    {
        optionsPanel.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void ChangeVolumeMenu(float vol) 
    {
        this.vol = vol;
    }
    
    
}
