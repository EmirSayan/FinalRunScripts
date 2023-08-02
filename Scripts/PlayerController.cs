using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10f;
    public bool isOnGround;
    public bool gameOver = false;
    public bool gameOverAD = false;
    public float turnSpeed;
    public Zombie zombieScript;
    public GameObject shotGun;
    public GameObject gameCanvas;
    public GameObject gamePausedCanvas;
    public GameObject uiCanvas;
    public Joystick joystick;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    private AudioSource playerrAudio;
    public GameObject bullet;
    private Rigidbody playerRb;
    private Vector3 bulletVector = new Vector3(-0.001f,0.62f,1);
    void Start()
    {
        Time.timeScale = 1;
        playerRb = GetComponent<Rigidbody>();
        playerrAudio = GetComponent<AudioSource>();
        gameOver = false;
        gameOverAD = false;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
        xRange();
        
        if(gameOver == true) // When the game is over
        {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-68.507f,0,0), turnSpeed * Time.deltaTime);
        gameCanvas.SetActive(false); // hide the buttons and display the 'Game Over' message
        shotGun.SetActive(false);
        playerRb.constraints = RigidbodyConstraints.FreezeAll; // player cannot move.
        StartCoroutine(ShowAd());
        }
    }
    
    public void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Ground")) // The character should be able to jump as long as it can touch the ground (necessary code to prevent jumping while in the air).
        {
            isOnGround = true;
        }else if(collision.gameObject.CompareTag("Engel")) // When the character touches an obstacle, the game should end.
        {
            gameOver = true;
            Sound();
            Debug.Log("Engele Çarptın!");
        }else if(collision.gameObject.CompareTag("Zombie")) // When the character touches an obstacle, the game should end.
        {
            gameOver = true;
            Sound();
            Debug.Log("Zombiye Çarptın!");
        }
    }
    void MoveControl() // Character movement
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(gameOver == false)
        {
            if(joystick.Horizontal >= .2f)
            {
                transform.Translate(Vector3.right * joystick.Horizontal * speed * Time.deltaTime);
            }else if (joystick.Horizontal <= -.2f)
            {
                transform.Translate(Vector3.left * joystick.Horizontal * -speed * Time.deltaTime);
            }
        }
        
    }
    void xRange() // The character should not be able to pass through certain distances while moving to the right and left.
    {
         if(transform.position.x < -4.38f)
        {
                transform.position = new Vector3(-4.38f , transform.position.y , transform.position.z);
        }
        if(transform.position.x > 8.45f)
        {
                transform.position = new Vector3(8.45f , transform.position.y , transform.position.z);
        }
    }
    public void Fire()
    {
        if(gameOver == false)
        {
            Instantiate(bullet, gameObject.transform.position + bulletVector, gameObject.transform.rotation);
        }
    }

    public void Jump()
    {
        if(isOnGround == true && gameOver == false) // If the character is on the ground and the game is not over, character can jump.
        {
        playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
        playerrAudio.PlayOneShot(jumpSound, 5.0f);
        isOnGround = false;
        }
    }
    public void Sound()
    {
        if(gameOver == true)
        {
            playerrAudio.PlayOneShot(deathSound, 5.0f);
            playerrAudio.PlayOneShot(jumpSound, 5.0f);
        }
    }
    public void Pause()
    {
        gameCanvas.SetActive(false);
        gamePausedCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void Rasume()
    {
        gamePausedCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        Time.timeScale = 1;
    }
    IEnumerator ShowAd()
    {
        yield return new WaitForSeconds(1.3f);
        gameOverAD = true;
        uiCanvas.SetActive(true); 
    }
}
