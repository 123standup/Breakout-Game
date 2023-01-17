using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 20f;
    private float input;
    private Rigidbody paddle;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() 
    {
        // left will make the paddle move right (postive x is face toward left)
        paddle.velocity = Vector3.left * input * speed;
    }
}
