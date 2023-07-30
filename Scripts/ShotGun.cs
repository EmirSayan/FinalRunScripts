using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    private Animator playerAnimasyon;
    public GameObject player;
    public GameObject bullet;
    public AudioClip fireSound;
    public ParticleSystem atesEfekt;
    private AudioSource playerAudio;
    private PlayerController playerController;
    private Vector3 mermiMesafe = new Vector3(-0.001f,0.62f,1);
    private bool anim;
    public float fireRate = 2f;
    public float nextTimeToFire = 0.0f;
    void Start()
    {
        playerAnimasyon  = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim == true)
        {
            playerAnimasyon.SetBool("Ates", true);
        }
        else if(anim == false)
        {
            playerAnimasyon.SetBool("Ates", false);
        }
        
    }
    public void AnimAndSfx()
    {
        if(Time.time >= nextTimeToFire)
        {
            anim = true;
            atesEfekt.Play();
            playerAudio.PlayOneShot(fireSound, 0.5f);
            Instantiate(bullet, player.transform.position + mermiMesafe, player.transform.rotation);
            nextTimeToFire = Time.time + fireRate;
            StartCoroutine(AtesSuresi());
        }
    }

    IEnumerator AtesSuresi()
    {
        yield return new WaitForSeconds(0.7f);
        anim = false;
    }
}
