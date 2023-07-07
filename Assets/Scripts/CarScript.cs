using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float acceleration;
    public float turnfactor;
    Rigidbody2D carbody;
    public float drift;
    public float Speed;
    public float AngularSpeed;



    float accelerating = 0;
    float steering = 0;
    float rotation = 0;

    void Start()
    {
        acceleration = 3F;
        turnfactor = 1.8F;
        drift = 0.85F;
        carbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            carbody.drag = Mathf.Lerp(carbody.drag, 10F, Time.deltaTime * 10);
        }
    }
    void FixedUpdate()
    {
        Speed = carbody.velocity.magnitude;
        AngularSpeed = carbody.angularVelocity;
        Accelerate();
        Drift();
        Steer();
    }

    void Accelerate()
    {
        if (accelerating == 0)
        {
            carbody.drag = Mathf.Lerp(carbody.drag, 3F, Time.deltaTime * 2);
        }
        else
        {
            carbody.drag = 0;
        }
        Vector2 acceleratrionvector = transform.up * acceleration * accelerating;
        carbody.AddForce(acceleratrionvector);
        if (carbody.velocity.magnitude > 3.5)
        {
            carbody.AddForce(-acceleratrionvector);
        }
    }
    void Steer()
    {
        
        float minspeedforrotation = carbody.velocity.magnitude / 15;
        float minrotationspeed = Mathf.Clamp01(minspeedforrotation);
        rotation = steering * turnfactor;
        if (accelerating == -1)
        {
            rotation = -rotation;
        }
        carbody.AddTorque(rotation * minrotationspeed);
        if (steering == 0)
        {
            carbody.angularVelocity = Mathf.Lerp(carbody.angularVelocity, 0F, Time.deltaTime * 9);
        }
        if (accelerating == 0)
        {
            carbody.angularVelocity = Mathf.Lerp(carbody.angularVelocity, 0F, Time.deltaTime * 3);
        }
        if (accelerating == -1)
        {
            if (carbody.angularVelocity >= 500 || carbody.angularVelocity <= -500)
            {
                carbody.AddTorque(-(rotation * minrotationspeed));
            }
        }
        else
        {
            if (carbody.angularVelocity >= 250 || carbody.angularVelocity <= -250)
            {
                carbody.AddTorque(-(rotation * minrotationspeed));
            }
        }
    }
    
    void Drift()
    {
        Vector2 forwardvelocity = transform.up * Vector2.Dot(carbody.velocity, transform.up);
        Vector2 horizontalvelocity = transform.right * Vector2.Dot(carbody.velocity, transform.right);

        carbody.velocity = forwardvelocity + horizontalvelocity * drift;

    }
    public void input(Vector2 inputvector)
    {
        accelerating = inputvector.y;
        steering = inputvector.x; 
    }
}
