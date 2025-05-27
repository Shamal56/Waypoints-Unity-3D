using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{

    public Transform[] waypoints;
    public float speed = 5f;

    private int currentWaypointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0)
            return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position);
        float distance = direction.magnitude;

        direction.Normalize();

        float speedFactod = Mathf.Clamp01(distance);
        float step = speed * speedFactod * Time.deltaTime;

        transform.position += direction * step;

        if (distance < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
