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
        SceneManager.LoadScene(0); // Restart butonuna tıklandığında 0. sahneye (Oynanış sahnesine) geri dönsün (Oyun yeniden başlasın)
    }
}
