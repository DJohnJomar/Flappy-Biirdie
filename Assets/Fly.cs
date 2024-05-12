using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private float velocity = 7.5f;
    [SerializeField] private float rotationSpeed = 20f;
    private Rigidbody2D rb;
    AudioManager audioManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        //Increases the vertical velocity by the velocity variable d
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector2.up * velocity;
            audioManager.PlaySFX(audioManager.jump);

        }
    }

    private void FixedUpdate()
    {
        //Changes object's rotation based on y speed
        transform.rotation = Quaternion.Euler(0,0,rb.velocity.y*rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When collided with anything, it calls the GameManager's GameOver method to call the game over sequence
        audioManager.PlaySFX(audioManager.death);
        audioManager.StopBackgroundMusic();
        GameManager.instance.GameOver(); 
    }
}
