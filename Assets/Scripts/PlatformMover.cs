using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] GameObject[] points;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, points[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= points.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, points[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}