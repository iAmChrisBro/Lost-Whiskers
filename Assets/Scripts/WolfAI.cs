using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAI : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private Transform wayPoints;
    private int currentWayPoint;

    [Header("Components")]
    NavMeshAgent agent;
    private bool playerDead = false;
    private bool canSeePlayer = false;
    private FieldOfView fov;
    private Transform target;
    private NavMeshAgent nav;

    public float followSpeed = 5f;  // Speed at which the object will follow the target
    public float stoppingDistance = 2f; // Minimum distance from the target before stopping

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<FieldOfView>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fov.CanSeePlayer)
        {
            canSeePlayer = true;
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        if (canSeePlayer)
            FollowPlayer();
        else
            FollowPath();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerDead = true;
        }
    }

    public bool GetPlayerDead()
    {
        return playerDead;
    }

    private void FollowPath()
    {
        if (agent.remainingDistance <= 0.2f && !canSeePlayer)
        {
            currentWayPoint++;

            if (currentWayPoint >= wayPoints.childCount)
            {
                currentWayPoint = 0;
            }

            agent.SetDestination(wayPoints.GetChild(currentWayPoint).position);
        }
    }

    private void FollowPlayer()
    {
        if(target != null) 
        {
            agent.SetDestination(target.transform.position);
        }
       
    }
}
