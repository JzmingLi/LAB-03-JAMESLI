using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{
    [SerializeField] GameObject target;
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
        animator.speed = agent.speed/2;
        if (isWalking)
        {
            agent.enabled = true;
            agent.destination = target.transform.position;
        }
        else agent.enabled = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("ATTACK");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("WALK");
        }
    }
}
