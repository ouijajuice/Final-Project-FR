using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TwoDRandomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;
    public Transform centrePoint;
    public float playerDetectionRange;
    public string playerTag = "Player";
    public string gameOverSceneName;

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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Debug.Log("Trigger Entered");
            SceneManager.LoadScene(gameOverSceneName);
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), playerDetectionRange);

        foreach (Collider2D collider in colliders)
        {
            //Debug.Log("Collider: " + collider.gameObject.name);

            if (collider.CompareTag(playerTag))
            {
                //return player is in range
                //Debug.Log("player detected");
                return collider.gameObject;
            }
        }

        //return player is not in range
        //Debug.Log("player not detected");
        return null;
    }
}