using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed;
    public float turningSpeed = 50f;
    public float breakspeed = 12f;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;

    public void Update()
    {
        Drive();
    }

    public void Drive()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;
            if(destinationDistance >= breakspeed)
            {
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
}
