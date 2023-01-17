using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
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

    // trigger when collide with ball
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject); // destroy brick
        brickManager.RemoveBrick(this); // remove brick from prefab
        ball.Accelerate(); // boost ball speed
    }
}
