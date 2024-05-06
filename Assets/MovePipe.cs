using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed *Time.deltaTime;
    }
}
