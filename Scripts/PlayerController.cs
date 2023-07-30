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
    private Vector3 mermiMesafe = new Vector3(-0.001f,0.62f,1);
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
        
        if(gameOver == true) // Oyun bittiğinde:
        {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-68.507f,0,0), turnSpeed * Time.deltaTime);
        gameCanvas.SetActive(false); // buttonlar yok olsun, oyun bitti yazısı aktif olsun
        shotGun.SetActive(false);    // Oyuncunun konumu donsun
        playerRb.constraints = RigidbodyConstraints.FreezeAll; // Oyuncu hareket edemesin
        StartCoroutine(ReklamGoster());
        }
    }
    
    public void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Ground")) // Karakter yere değebildiği sürece zıplayabilsin (havada zıplayamaması için gerekli kod.)
        {
            isOnGround = true;
        }else if(collision.gameObject.CompareTag("Engel")) // Karakter Engele değdiği zaman oyun bitsin.
        {
            gameOver = true;
            Ses();
            Debug.Log("Engele Çarptın!");
        }else if(collision.gameObject.CompareTag("Zombie")) // Karakter zombiye değdiği zaman oyun bitsin.
        {
            gameOver = true;
            Ses();
            Debug.Log("Zombiye Çarptın!");
        }
    }
    void MoveControl() // Karakter hareketleri.
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
    void xRange() // Karakter sağa sola gidemesin diye yazılmış kod.
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
    public void AtesEt() // Ateş etme kodu.
    {
        if(gameOver == false)
        {
            Instantiate(bullet, gameObject.transform.position + mermiMesafe, gameObject.transform.rotation);
        }
    }

    public void Zipla() // Zıplama kodu.
    {
        if(isOnGround == true && gameOver == false) // Karakter yerdeyse ve oyun bitmediyse zıplayabilsin.
        {
        playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
        playerrAudio.PlayOneShot(jumpSound, 5.0f);
        isOnGround = false;
        }
    }
    public void Ses()
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
    IEnumerator ReklamGoster()
    {
        yield return new WaitForSeconds(1.3f);
        gameOverAD = true;
        uiCanvas.SetActive(true); 
    }
}
