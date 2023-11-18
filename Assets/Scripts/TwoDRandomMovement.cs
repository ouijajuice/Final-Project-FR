using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TwoDRandomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;
    public Transform centrePoint;
    public float playerDetectionRange;
    public string playerTag = "Player";

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        //see if the player is in range
        GameObject player = FindPlayerInRange();

        if (player != null)
        {
            //player is in range, move towards player
            agent.SetDestination(player.transform.position);
        }
        else if (agent.remainingDistance <= agent.stoppingDistance)
        {
            //player is not in range, move to random point
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    GameObject FindPlayerInRange()
    {
        //find object with player tag
        Collider[] colliders = Physics.OverlapSphere(transform.position, playerDetectionRange);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(playerTag))
            {
                //return player is in range
                return collider.gameObject;
            }
        }

        //return player is not in range
        return null;
    }
}