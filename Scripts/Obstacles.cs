using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float kenar = -20.0f;
    private float speed = 16.0f;
    private Score scoreScript;
    private PlayerController playerControllerscript;
    void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreScript = GameObject.Find("Score").GetComponent<Score>();
    }

    
    void Update()
    {
        DestroyRange();
        MoveForward();

    }

    void DestroyRange()  // Objenin z ekseni kenardan (-20.0f) küçük olursa, obje yok olsun.
    {
        if(transform.position.z < kenar) 
        {
            Destroy(gameObject);
        }
    }
    void MoveForward()  // Oyun bitmediği süre boyunca obje ileri doğru gitsin.
    {
        if(playerControllerscript.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime* speed);
        }
    }
}
