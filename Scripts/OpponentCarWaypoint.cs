using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCarWaypoint : MonoBehaviour
{
    [Header("Opponent Car")]
    public OponentCar oponentCar;
    public Waypoint currentWaypoint;

    public void Awake()
    {
        oponentCar = GetComponent<OponentCar>();
    }
    private void Start()
    {
        oponentCar.LocateDestination(currentWaypoint.GetPosition());
    }
    private void Update()
    {
        if (oponentCar.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            oponentCar.LocateDestination(currentWaypoint.GetPosition());
        }
    }
}
