using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    
    private float accelRatio = 1.03f;
    private float maxSpeed = 20f;
    private float minYVeloci = 1f;
    private Rigidbody ball;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        // bouncy adjustment for low horizontal momentum
        float velociY = System.Convert.ToSingle(ball.velocity.y);
        if (velociY < minYVeloci && Mathf.Sign(velociY) == 1)
        {
            ball.AddForce(new Vector3(0f, 50f, 0f));    
        }
        else if (velociY > -1 * minYVeloci && Mathf.Sign(velociY) == -1)
        {
            ball.AddForce(new Vector3(0f, -30f, 0f));
        }
        ball.velocity = speed * (ball.velocity.normalized);
    }

    // accelerate ball speed
    public void Accelerate()
    {
        speed *= accelRatio;
        speed = Mathf.Min(speed, maxSpeed);
        ball.velocity = speed * (ball.velocity.normalized);
    }

    // reset ball speed with random orient
    public void Respawn() 
    {
        speed = 10f;
        transform.position = Vector3.zero;
        ball.velocity = speed * Random.insideUnitCircle.normalized;
    }
}
