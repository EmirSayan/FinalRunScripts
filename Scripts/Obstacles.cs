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

    void DestroyRange()  //If the object's z-axis is less than the edge (-20.0f), let the object disappear
    {
        if(transform.position.z < kenar) 
        {
            Destroy(gameObject);
        }
    }
    void MoveForward()  // During the game is not over, let the object move forward
    {
        if(playerControllerscript.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime* speed);
        }
    }
}
