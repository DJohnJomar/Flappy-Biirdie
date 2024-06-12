using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 1f;
    [SerializeField] private float speedIncrease = 0.1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed *Time.deltaTime;

        // Check for left mouse button or spacebar press
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            //Adds a sort of Momentum
            //Pipe speed increases per flap
            speed += speedIncrease;
        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
