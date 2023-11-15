using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class script1 : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
