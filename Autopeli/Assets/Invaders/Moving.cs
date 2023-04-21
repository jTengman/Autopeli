using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moving : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Transform[] points;
    int current;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        current = 0;
        _agent.SetDestination(points[current].position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == points[current].transform)
        {
            if (current == points.Length - 1)
            {
                current = 0;
            }
            else
            {
                current++;
            }

            
            _agent.SetDestination(points[current].position);
            
            print(current);



        }
    }
    // Update is called once per frame
    void Update()

    {   

            
    }
}
