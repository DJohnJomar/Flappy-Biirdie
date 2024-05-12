using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = .5f;
    [SerializeField] private GameObject _pipe;
    private float timer; 
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        //Set interval of pipe spawn
        //Set to ~1.5 seconds
        if(timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        //Instantiates a pipe object
        //Pipe's position is relative to the pipe spawners position in the x axis,
        //the y position varies from a random number between the set height range
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        //The spawned pipe object is destroyed after 10 seconds (out of frame)
        Destroy(pipe, 10f);
    }
}
