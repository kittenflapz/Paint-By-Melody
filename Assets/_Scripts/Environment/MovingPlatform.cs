using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
 
    [SerializeField]
    float speed = 8;

    [SerializeField]
    float waypointRadius = 1;

    int counter = 0;

    [SerializeField]
    private bool shouldMove;

    void Update()
    {
        if (shouldMove)
        {
            FollowPath();
        }
    }


    public void StartMoving()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        shouldMove = true;
    }

    private void FollowPath()
    {
        if (Vector3.Distance(waypoints[counter].transform.position, transform.position) < waypointRadius)
        {
            counter++;
            if (counter >= waypoints.Length)
            {
                counter = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[counter].transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.DetachChildren();
        }
    }
}
