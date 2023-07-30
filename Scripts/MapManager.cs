using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
   private float kenar = -20.0f;
    private float speed = 16.0f;
    private PlayerController playerControllerscript;
    void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        DestroyRange();
        MoveForward();

        if (transform.position.z < 0.3f)
        {
            transform.position = new Vector3(27.48f,5.1f,76.689f);
        }
    }

    void DestroyRange()
    {   // Obje kenar (-20.0f) noktasına geldiğinde yok olsun.
        if(transform.position.z < kenar)
        {
            Destroy(gameObject);
        }
    }
    void MoveForward()
    {   // Oyun devam ettiği sürece Obje speed değişkeni ile çarpılacak şekilde vektörel hareket yapsın.
        if(playerControllerscript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime* speed);
        }
    }
}
