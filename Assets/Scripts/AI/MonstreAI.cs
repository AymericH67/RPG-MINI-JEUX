using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstreAI : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private NavMeshAgent agent;
    private bool hasDestination;
    public GameObject player;
    public AIStatData aiStat;

    [Header("Wandering parameters")]

    [Header("Stats")]

    [SerializeField] private float walkSpeed;
    [SerializeField] private float chaseSpeed;

    [SerializeField] private float wanderingWaitTimeMin;
    [SerializeField] private float wanderingWaitTimeMax;


    [SerializeField] private float wanderingDistanceMin;
    [SerializeField] private float wanderingDistanceMax;

    private void Start()
    {
        // reference dans le Ai data
        walkSpeed = aiStat.walkSpeed;
        chaseSpeed = aiStat.chaseSpeed;

        wanderingWaitTimeMin = aiStat.wanderingWaitTimeMin;
        wanderingWaitTimeMax = aiStat.wanderingWaitTimeMax;

        wanderingDistanceMin = aiStat.wanderingDistanceMin;
        wanderingDistanceMax = aiStat.wanderingDistanceMax;
    }

    private void Update()
    {
        // aller vers le joueur si on le connais si non se deplacer
        if(player != null)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = chaseSpeed;
        }
        else if(player = null)
        {
            StartCoroutine(GetNewDestination());
            agent.speed = walkSpeed;
        }

        // crée une nouvelle destination si l'ia l'a atteins
        if (agent.remainingDistance < 0.75 && !hasDestination)
        {
            agent.speed = walkSpeed;
            StartCoroutine(GetNewDestination());
        }
    }

    // renseigner le joueur si il rentre dans la zone de détéction
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    // déranseigner le joueur si il sort de la zone de détéction
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
        }
    }

    // créé la nouvelle destination du joueur
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
