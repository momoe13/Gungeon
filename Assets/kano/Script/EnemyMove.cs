using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent2D agent;
    [SerializeField]
    Transform target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
