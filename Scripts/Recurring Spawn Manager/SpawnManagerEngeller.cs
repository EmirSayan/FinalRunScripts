using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEngeller : MonoBehaviour
{
   // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    private PlayerController playerControllerScript;
    public float spawnPosZ = 74;
    private float startTime = 0.1f;
    private float repeatTime = 3.7f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomEngel", startTime, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEngel()
    {
        Vector3 spawnPos = new Vector3(2.84f,1.34f,spawnPosZ);
        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(enemyPrefabs[enemyIndex],spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}
