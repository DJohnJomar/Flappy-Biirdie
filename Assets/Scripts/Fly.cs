using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private float velocity = 7.5f;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float flapCD = .5f;
    private float cooldownTimer = 0f;
    private Rigidbody2D rb;
    AudioManager audioManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {


        // Update the cooldown timer
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        //Increases the vertical velocity by the velocity variable 
        //Player cannot flap if cooldown is not yet 0
        if (cooldownTimer <= 0f && Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Flap();

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

    private void Flap()
    {
        // Reset the cooldown timer by the specified flap cooldown
        cooldownTimer = flapCD;

        // Set the vertical velocity
        rb.velocity = Vector2.up * velocity;

        // Play flap sound effect
        audioManager.PlaySFX(audioManager.jump);
    }
}
