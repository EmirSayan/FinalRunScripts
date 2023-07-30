using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveForward : MonoBehaviour
{
    private Score scoreScript;
    public bool pal = false;
    public float speed = 100.0f;
    void Start()
    {
        scoreScript = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        DestroyBulletRange();
        if(pal == true)
        {
            Debug.Log("pal");
        }
    }
    void MoveForward() // Kurşun ateşlendiği an ileri gitsin
    {   
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void DestroyBulletRange() // Kurşun z ekseninde 60 ı geçerse yok olsun
    {   
        if(transform.position.z > 60)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Zombie") || other.gameObject.CompareTag("Engel")) // Kurşun Zombiye değdiğinde olacaklar :
        {
            pal = true;
            Destroy(gameObject);                 // Zombi yok olsun
            scoreScript.score += 50f;   // Puan 50 artsın
            
        }
    }
}
