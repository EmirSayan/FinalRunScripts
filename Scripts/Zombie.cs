using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie : MonoBehaviour
{
    private float speed = 16f;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public ParticleSystem bloodParticle;
    private PlayerController playerControllerscript;
    private AudioSource hitAudio;
    private AudioSource deathAudio;
    private float bound = -10.0f;
    private Animator zombieAnimation;
    private BoxCollider boxCollider;
    void Start()
    {
        hitAudio = GetComponent<AudioSource>();
        deathAudio = GetComponent<AudioSource>();
        zombieAnimation  = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        MoveForward();
        zRange();
        if(playerControllerscript.gameOver == true)
        {
            zombieAnimation.SetBool("Death", true);
        }
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            zombieAnimation.SetBool("Death", true);
            boxCollider.isTrigger = true;
            hitAudio.PlayOneShot(hitSound, 0.6f);
            hitAudio.PlayOneShot(deathSound, 0.2f);
            bloodParticle.Play();
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
        if(transform.position.z < bound)
        {
            Destroy(gameObject);
        }
    }
}
