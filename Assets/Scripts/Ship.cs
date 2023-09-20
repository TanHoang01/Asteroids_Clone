using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //Vector2 thrustDirection = new Vector2(1,0);
    const float ThrustForce = 2;
    const float rotateDegreesPerSecond = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // calculate rotation amount and apply rotation
        float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
        float rotationDirection = 0;

        if (Input.GetAxis("Rotate") < 0)
        {
            rotationDirection = rotationAmount;
        }

        if (Input.GetAxis("Rotate") > 0)
        {
            rotationDirection = -rotationAmount;
        }
        
        transform.Rotate(Vector3.forward, rotationDirection);

        // check if player click space button
        if (Input.GetAxis("Thrust") > 0)
        {
            float currentDeg = transform.eulerAngles.z;
            currentDeg *= Mathf.Deg2Rad;
            float newX = MathF.Cos(currentDeg);
            float newY = MathF.Sin(currentDeg);
            // add force to ship
            GetComponent<Rigidbody2D>().AddForce(new Vector2(newX,newY) * ThrustForce, ForceMode2D.Force);
        }
    }

    //private void FixedUpdate()
    //{
    //    // check if player click space button
    //    if (Input.GetAxis("Thrust") > 0)
    //    {
    //        // add force to ship
    //        GetComponent<Rigidbody2D>().AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
    //    }
    //}

    // Disables the behaviour when it is invisible
    private void OnBecameInvisible()
    {
        // get current position of the ship
        Vector2 currentPosition = transform.position;

        // set ship's position back to the camera
        currentPosition.x = -currentPosition.x;
        currentPosition.y = -currentPosition.y;
        transform.position = currentPosition;
    }
}
