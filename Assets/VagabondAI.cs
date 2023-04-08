using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VagabondAI : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private NavMeshAgent agent;
    private bool hasDestination;

    [Header("Wandering parameters")]

    [Header("Stats")]

    [SerializeField] private float walkSpeed;

    [SerializeField] private float wanderingWaitTimeMin;
    [SerializeField] private float wanderingWaitTimeMax;


    [SerializeField] private float wanderingDistanceMin;
    [SerializeField] private float wanderingDistanceMax;

    private void Update()
    {
        if (agent.remainingDistance < 0.75 && !hasDestination)
        {
            agent.speed = walkSpeed;
            StartCoroutine(GetNewDestination());
        }
    }

    IEnumerator GetNewDestination()
    {
        hasDestination = true;
        yield return new WaitForSeconds(Random.Range(wanderingWaitTimeMin, wanderingWaitTimeMax));

        Vector3 nextDestination = transform.position;
        nextDestination += Random.Range(wanderingDistanceMin, wanderingDistanceMax) * new Vector3(Random.Range(-1f, 1), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, wanderingDistanceMax, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        hasDestination = false;
    }
}
