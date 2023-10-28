using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl1 : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject attackTarget;
    [SerializeField] NavMeshAgent agent;
    bool isWalking = true;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }
}
