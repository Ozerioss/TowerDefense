﻿using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;


    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; //waypoint position - enemy position
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<= 0.3f)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject); // destroy enemy when he reaches last waypoint
            return;
        }
        
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
