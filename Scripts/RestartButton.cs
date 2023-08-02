using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestartButtonMethod()
    {
        SceneManager.LoadScene(0); // When the Restart button is clicked, it should return to Scene 0 (Gameplay scene) and restart the game.
    }
}
