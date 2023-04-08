using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstreAI : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private NavMeshAgent agent;
    private bool hasDestination;
    private bool isDead = false;
    public GameObject player;
    public GameObject dropPoint;
    public AIStatData aiStat;

    [Header("GameObjectToInstantiateOnDeath")]

    [SerializeField] private GameObject obj1;
    [SerializeField] private GameObject obj2;
    [SerializeField] private GameObject obj3;
    [SerializeField] private GameObject obj4;

    [Header("Stats")]

    private float walkSpeed;
    private float chaseSpeed;

    private float wanderingWaitTimeMin;
    private float wanderingWaitTimeMax;


    private float wanderingDistanceMin;
    private float wanderingDistanceMax;
    private float maxHealth;
    [SerializeField] public float currentHealth;

    private Vector3 spawnAI;

    private void Start()
    {
        // reference dans le Ai data
        walkSpeed = aiStat.walkSpeed;
        chaseSpeed = aiStat.chaseSpeed;

        wanderingWaitTimeMin = aiStat.wanderingWaitTimeMin;
        wanderingWaitTimeMax = aiStat.wanderingWaitTimeMax;

        wanderingDistanceMin = aiStat.wanderingDistanceMin;
        wanderingDistanceMax = aiStat.wanderingDistanceMax;

        maxHealth = aiStat.health;
        currentHealth = maxHealth;

        spawnAI = aiStat.spawnAI;
    }

    private void Update()
    {
        // aller vers le joueur si on le connais si non se deplacer
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = chaseSpeed;
        }
        else if (player = null)
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
        if (other.tag == "Player")
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

    public void TakeDammage(float damages)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damages;

        if (currentHealth <= 0)
        {
            print("ia is dead");

            // spawn des objets a la mort de l'ia  // ( obj1/2/3/4 = itemData)

            if (obj1 != null)
            {
                Instantiate(obj1, dropPoint.transform.position, Quaternion.identity);
            }
            if (obj2 != null)
            {
                Instantiate(obj2, dropPoint.transform.position, Quaternion.identity);
            }
            if (obj3 != null)
            {
                Instantiate(obj3, dropPoint.transform.position, Quaternion.identity);
            }
            if (obj4 != null)
            {
                Instantiate(obj4, dropPoint.transform.position, Quaternion.identity);
            }

            isDead = true;
            enabled = false;
            agent.enabled = false;
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