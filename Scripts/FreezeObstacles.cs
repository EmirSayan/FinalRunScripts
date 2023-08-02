using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObstacles : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody obstacleRb;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        obstacleRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.gameOver == true)
        {
            obstacleRb.constraints = RigidbodyConstraints.FreezeAll; // When the game is over, lock the positions of the obstacles (prevent them from moving).
        }
    }
}
