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
        SceneManager.LoadScene(1); // When the restart button is clicked, go back to the 1st menu (Game Menu).
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0); // When the menu button is clicked, go back to the 0th menu (Main Menu).
    }
}
