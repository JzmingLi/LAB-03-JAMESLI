using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = agent.speed;
        if (isWalking)
        {
            agent.enabled = true;
            agent.destination = target.transform.position;
        }
        else
        {
            agent.enabled = false;
            transform.LookAt(attackTarget.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == target)
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == target)
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
