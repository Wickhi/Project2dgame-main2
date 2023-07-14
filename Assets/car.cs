using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Variables to control car movement
    public float maxSpeed = 10f;
    public float acceleration = 50f;
    public float deceleration = 50f;
    public float brakingForce = 100f;
    public int numberOfGears = 6;
    public float[] gearRatios;

    // Private variables
    private float currentSpeed = 0f;
    private float currentRPM = 0f;
    private int currentGear = 1;
    private WheelCollider[] wheelColliders;
    private float maxSteeringAngle = 30f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the WheelCollider components
        wheelColliders = GetComponentsInChildren<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate RPM and current speed
        currentRPM = Mathf.Clamp(Mathf.Abs(verticalInput) * 1000f, 0f, 8000f);
        currentSpeed = currentRPM / gearRatios[currentGear - 1] * 0.1f;

        // Calculate acceleration and deceleration
        float accelerationAmount = 0f;
        if (verticalInput > 0)
        {
            accelerationAmount = acceleration * Time.deltaTime;
        }
        else if (verticalInput < 0)
        {
            accelerationAmount = -deceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed + accelerationAmount, -maxSpeed, maxSpeed);

        // Check if the car should shift up or down
        if (verticalInput > 0 && currentRPM >= 7000f && currentGear < numberOfGears)
        {
            currentGear++;
        }
        else if (verticalInput < 0 && currentGear > 1)
        {
            currentGear--;
        }

        // Apply brakes if no arrow key is pressed
        if (verticalInput == 0 && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            Brake();
        }

        // Steer the car based on horizontal input
        float steeringAngle = horizontalInput * maxSteeringAngle;
        foreach (WheelCollider wheel in wheelColliders)
        {
            wheel.steerAngle = steeringAngle;
        }

        // Move the car based on current speed
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    // Function to apply braking force
    void Brake()
    {
        float brakeForce = brakingForce * Time.deltaTime;
        if (currentSpeed > 0)
        {
            currentSpeed = Mathf.Max(0, currentSpeed - brakeForce);
        }
        else if (currentSpeed < 0)
        {
            currentSpeed = Mathf.Min(0, currentSpeed + brakeForce);
        }
    }
}

