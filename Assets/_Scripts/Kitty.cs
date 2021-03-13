using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kitty : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidBody;

    [SerializeField]
    Transform playerFollowPoint;

    NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerFollowPoint.position) > 2.5)
        {
            animator.SetInteger("Walk", 1);
            FollowPlayer(); 
        }
        else
        {
            animator.SetInteger("Walk", 0);
        }
    }

    public void FollowPlayer()
    {
        agent.destination = playerFollowPoint.position;
    }

}
