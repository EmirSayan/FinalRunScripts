using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEngel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    private PlayerController playerControllerScript;
    public float spawnPosZ = 74;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        Vector3 spawnPos = new Vector3(2.84f,1.34f,spawnPosZ);
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
