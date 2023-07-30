using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1); // Restart butonuna tıklandığında 1. Menüye(Oyuna) geri dönsün
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0); // Menü butonuna tıklandığında 0. Menüye(Ana Menüye) dönsün
    }
}
