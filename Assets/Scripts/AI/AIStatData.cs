using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI", menuName = "AI/New AI Stats")]
public class AIStatData : ScriptableObject
{
    public float walkSpeed;
    public float chaseSpeed;

    public float wanderingWaitTimeMin;
    public float wanderingWaitTimeMax;

    public float wanderingDistanceMin;
    public float wanderingDistanceMax;

    public float damage;
    public float health;
}
