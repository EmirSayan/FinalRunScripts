using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie : MonoBehaviour
{
    private float speed = 16f;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public ParticleSystem kanEfekt;
    private PlayerController playerControllerscript;
    private AudioSource hitAudio;
    private AudioSource deathAudio;
    private float kenar = -10.0f;
    private Animator zombieAnimasyon;
    private BoxCollider boxCollider;
    void Start()
    {
        hitAudio = GetComponent<AudioSource>();
        deathAudio = GetComponent<AudioSource>();
        zombieAnimasyon  = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();

        /*
        if(scoreScript.scoreMiktari > 1000)
        {
            speed = 30;
            Debug.Log(speed);
        } else if(scoreScript.scoreMiktari > 2000)
        {
            speed = 19;
            Debug.Log(speed);
        } else if(scoreScript.scoreMiktari > 3000)
        {
            speed = 20;
            Debug.Log(speed);
        }
        */
    }

    void Update()
    {
        MoveForward();
        zRange();
        if(playerControllerscript.gameOver == true)
        {
            zombieAnimasyon.SetBool("Death", true);
        }
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            zombieAnimasyon.SetBool("Death", true);
            boxCollider.isTrigger = true;
            hitAudio.PlayOneShot(hitSound, 0.6f);
            hitAudio.PlayOneShot(deathSound, 0.2f);
            kanEfekt.Play();
        }
        if(other.gameObject.CompareTag("Alice"))
        {
            hitAudio.PlayOneShot(deathSound, 0.2f);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            hitAudio.PlayOneShot(deathSound, 0.2f);
        }
    }

    void MoveForward()
    {
        if(playerControllerscript.gameOver == false)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    void zRange()
    {
        if(transform.position.z < kenar)
        {
            Destroy(gameObject);
        }
    }
}
