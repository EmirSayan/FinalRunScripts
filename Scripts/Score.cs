using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public TextMeshProUGUI scoreTxet;
    public TextMeshProUGUI lastScore;
    public TextMeshProUGUI lastScore2;
    public float score;
    public float increasePerSecond;



    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0f;
        increasePerSecond = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            scoreTxet.text = (int)score + " ";
        score += increasePerSecond * Time.deltaTime;
        }
        if(score > PlayerPrefs.GetInt("_highScore"))
        {
            PlayerPrefs.SetInt("_highScore", (int)score);
        }
        if(playerControllerScript.gameOver == false)
        {
            lastScore.text = (int)score + " ";
        score += increasePerSecond * Time.deltaTime;
        
        lastScore2.text = (int)score + " ";
        score+= increasePerSecond * Time.deltaTime;
        }
    }
}
