using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_Text highScore;
    public GameObject canvas;
    public GameObject howToPlayButton;
    public GameObject cancelButton;
    public GameObject textBack;
    public GameObject howToPlayText;
    public GameObject Credit1;
    public GameObject Credit2;
    public GameObject Credit3;
    public GameObject loadingText;
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("_highScore").ToString();
        loadingText.SetActive(false);
    }
    public void PlayButton()
    {   // When the Play button is clicked, go to Scene 1 (Gameplay scene)
        SceneManager.LoadScene(1);
        loadingText.SetActive(true);
    }
    public void MenuButton()
    {   // When the Menu button is clicked, go to Scene 0 (Main Menu)
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {   // When the Quit button is clicked, exit the game
        Application.Quit();
    }
    public void HowToPlay()
    {
        canvas.SetActive(false);
        howToPlayButton.SetActive(false);
        cancelButton.SetActive(true);
        textBack.SetActive(true);
        howToPlayText.SetActive(true);
        Credit1.SetActive(true);
        Credit2.SetActive(true);
        Credit3.SetActive(true);
    }
    public void Cancel()
    {
        howToPlayButton.SetActive(true);
        cancelButton.SetActive(false);
        textBack.SetActive(false);
        howToPlayText.SetActive(false);
        canvas.SetActive(true);
        Credit1.SetActive(false);
        Credit2.SetActive(false);
        Credit3.SetActive(false);
    }
}
