using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{    
    private Ball ball;
    private BrickManager brickManager;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        brickManager = FindObjectOfType<BrickManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Trigger when collide with ball -> reset game
    private void OnTriggerEnter(Collider other)
    {
        ball.Respawn();
        brickManager.ResetLevel();
    }
}
