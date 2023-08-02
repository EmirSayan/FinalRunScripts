using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
   private float bound = -20.0f;
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
    {   // When the object reaches the bound (-20.0f) point, let it disappear.
        if (transform.position.z < bound)
        {
            Destroy(gameObject);
        }
    }
    void MoveForward()
    {   // During the game, the object should move with vector motion, being multiplied by the 'speed' variable
        if (playerControllerscript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime* speed);
        }
    }
}
