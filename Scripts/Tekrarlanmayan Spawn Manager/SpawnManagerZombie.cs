using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerZombie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    private PlayerController playerControllerScript;
    public float spawnPosZ = 70;

    void Start()
    {
playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        Vector3 spawnPos = new Vector3(Random.Range(-4.38f,8.45f),0,spawnPosZ);
        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(enemyPrefabs[enemyIndex],spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
