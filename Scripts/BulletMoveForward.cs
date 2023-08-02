using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveForward : MonoBehaviour
{
    private Score scoreScript;
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
    }
    void MoveForward() 
    {   
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void DestroyBulletRange()
    {   
        if(transform.position.z > 60)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Zombie") || other.gameObject.CompareTag("Obstacle")) // What happens when the bullet hits a zombie or an obstacle:
        {
            pal = true;
            Destroy(gameObject); // The zombie or obstacle should disappear.
            scoreScript.score += 50f;// Increase the score by 50.
        }
    }
}
