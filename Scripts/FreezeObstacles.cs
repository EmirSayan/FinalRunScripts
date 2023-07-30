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
            obstacleRb.constraints = RigidbodyConstraints.FreezeAll; // Oyun bittiğinde Engellerin konumu kilitlensin (Hareket edemesin) 
        }
    }
}
