using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAttaque : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    
    [SerializeField] private PlayerStats playerStats;
    public AIStatData aiStat;

    public float damageDealt;

    private void Start()
    {
        damageDealt = aiStat.damage;
    }

    private void Update()
    {
        if (player != null)
        {
            playerStats = player.GetComponent<PlayerStats>();
            Attaque();
        }
        else if (player = null) 
        { 
            playerStats = null;
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

    private void Attaque()
    {
        playerStats.TakeDamage(damageDealt);
    }
}
