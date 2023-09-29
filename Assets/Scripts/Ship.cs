using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;


public class Ship : MonoBehaviour
{
    //Vector2 thrustDirection = new Vector2(1,0);
    const float thrustForce = 3;
    const float rotateDegreesPerSecond = 70;
    const float distancePerSecond = 7;

    //get screen width and height
    float screenTop;
    float screenBottom;
    float screenLeft;
    float screenRight;

    // Start is called before the first frame update
    void Start()
    {
        screenTop = ScreenUtils.ScreenTop;
        screenBottom = ScreenUtils.ScreenBottom;
        screenLeft = ScreenUtils.ScreenLeft;
        screenRight = ScreenUtils.ScreenRight;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Thrusting();
    }

    // Control Ship Movement
    void Moving()
    {
        // calculate rotation amount and apply rotation
        float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
        float rotationDirection = 0;

        // player click left button
        if (Input.GetAxis("Rotate") < 0)
        {
            rotationDirection = rotationAmount;
        }

        // player click right button
        if (Input.GetAxis("Rotate") > 0)
        {
            rotationDirection = -rotationAmount;
        }

        transform.Rotate(Vector3.forward, rotationDirection);

        // player click up button
        if (Input.GetAxis("Move") > 0)
        {
            transform.Translate(Vector3.right * distancePerSecond * Time.deltaTime);
        }
    }

    // Control Ship Thrusting
    void Thrusting()
    {
        //check if player click space button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.right * thrustForce);
        }
    }

    private void OnBecameInvisible()
    {
        // get current position of the ship
        Vector2 currentPosition = transform.position;

        // set ship's position back to the camera
        if (currentPosition.y > screenTop || currentPosition.y < screenBottom)
        {
            currentPosition.y = -currentPosition.y;
            transform.position = currentPosition;
        }

        if (currentPosition.x < screenLeft || currentPosition.x > screenRight)
        {
            currentPosition.x = -currentPosition.x;
            transform.position = currentPosition;
        }
    }
}
