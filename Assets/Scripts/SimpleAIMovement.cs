using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SimpleAIMovement : MonoBehaviour
{
    [Tooltip("Set AI movement speed")]
    public float aiSpeed;
    [Tooltip("AI destination/target")]
    public Transform dest;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(dest.position * 1f);
           
    }
}
