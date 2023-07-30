using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    private PlayerController playerControllerScript;
    public float spawnPosZ = 70;
    private float baslamaZamani = 0.1f;
    private float tekrarAralıgı = 3.7f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomEnemy", baslamaZamani, tekrarAralıgı);
        // 8.45f i -4.38f
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-4.38f,8.45f),0,spawnPosZ);
        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(enemyPrefabs[enemyIndex],spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}
