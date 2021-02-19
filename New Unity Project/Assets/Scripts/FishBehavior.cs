using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishBehavior : MonoBehaviour
{
    public Transform turtle;
    
    public Transform patrolRoute;

    public List<Transform> locations;

    private int locationIndex = 0;

    private NavMeshAgent fish;

    void Start()
    {
        fish = GetComponent<NavMeshAgent>();

        turtle = GameObject.Find("TurtleRed").transform;

        InitializePatrolRoute();

        MoveToNextPatrolLocation();
    }

    void Update()
    {
        if(fish.remainingDistance < 0.2f && !fish.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if(locations.Count == 0)
        {
            return;
        }

        fish.destination = locations[locationIndex].position;

        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "TurtleRed")
        {
            fish.destination = turtle.position;

            Debug.Log("Turtle incoming!!! Defend the food!!!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name == "TurtleRed")
        {
            Debug.Log("Turtle out of range, resume patrol");
        }
    }
}
