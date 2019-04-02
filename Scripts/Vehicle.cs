//Author: Yasiru Karunawansa
//Purpose: controls spaceship behaviour
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    // Unnecessary
    //public float speed;                       // Speed of the vehicle, not needed anymore

    // Necessary
    public float deAccelRate;                   //small constant rate of deacceleration
    public float accelRate;                     // Small, constant rate of acceleration
    public Vector3 vehiclePosition;             // Local vector for movement calculation
    public Vector3 direction;                   // Way the vehicle should move
    public Vector3 velocity;                    // Change in X and Y
    public Vector3 acceleration;                // Small accel vector that's added to velocity
    public float angleOfRotation;               // 0 
    public float maxSpeed;                      // 0.5 per frame, limits mag of velocity

    public float height;
    public float width;
    // Use this for initialization
    void Start ()
    {
        vehiclePosition = new Vector3(0, 0, 0);     // Or you could say Vector3.zero
        direction = new Vector3(1, 0, 0);           // Facing right
        velocity = new Vector3(0, 0, 0);            // Starting still (no movement)

        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        Debug.Log(width);
        Debug.Log(height);

    }
	
	// Update is called once per frame
	void Update ()
    {
        RotateVehicle();

        Drive();

        SetTransform();

        Wrap(height,width);
    }

    /// <summary>
    /// Changes / Sets the transform component
    /// </summary>
    public void SetTransform()
    {
        // Rotate vehicle sprite
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);

        // Set the transform position
        transform.position = vehiclePosition;
    }

    /// <summary>
    /// acceleration and deacceleraton of vehicle
    /// </summary>
    public void Drive()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Accelerate
            // Small vector that's added to velocity every frame
            acceleration = accelRate * direction;

            // We used to use this, but acceleration will now increase the vehicle's "speed"
            // Velocity will remain intact from one frame to the next
            //velocity = direction * speed;             // Unnecessary
            velocity += acceleration;

            // Limit velocity so it doesn't become too large
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

            // Add velocity to vehicle's position
            vehiclePosition += velocity;
            //Debug.Log(velocity);
        }
      else
      {
            velocity = velocity * 0.95f;
            if (velocity.sqrMagnitude < 0.0001f)
            {
                velocity = Vector3.ClampMagnitude(velocity, 0);
            }
       
     
      }
        vehiclePosition += velocity;
    }

    /// <summary>
    /// rotation of vehicle
    /// </summary>
    public void RotateVehicle()
    {
        // Player can control direction
        // Left arrow key = rotate left by 2 degrees
        // Right arrow key = rotate right by 2 degrees
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angleOfRotation += 2;
            direction = Quaternion.Euler(0, 0, 2) * direction;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            angleOfRotation -= 2;
            direction = Quaternion.Euler(0, 0, -2) * direction;
        }
    }
    /// <summary>
    /// check edges for wrapoping
    /// </summary>
    /// <param name="camHeight"></param>
    /// <param name="camWidth"></param>
    public void Wrap(float camHeight, float camWidth)
    {
        if (transform.position.y > camHeight / 2)
        {

            vehiclePosition = new Vector3(transform.position.x, -transform.position.y, 0);

        }
        else if (transform.position.y < -camHeight / 2)
        {
            vehiclePosition = new Vector3(transform.position.x, -transform.position.y, 0);
        }
        if (transform.position.x > camWidth/2)
        {

            vehiclePosition = new Vector3(-transform.position.x, transform.position.y, 0);

        }
        else if (transform.position.x < -camWidth/2 )
        {
            vehiclePosition = new Vector3(-transform.position.x, transform.position.y, 0);
        }

    }
}

