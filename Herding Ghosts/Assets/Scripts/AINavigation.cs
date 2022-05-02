using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {

        DrawPath();
    }

    public void SetDestination(Transform transform)
    {
        agent.SetDestination(transform.position);
    }

    public void SetDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }

    void DrawPath()
    {
        for (int i = 0; i < agent.path.corners.Length - 1; i++)
        {
            Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1], Color.red);
        }
    }

    public void StopNavigation()
    {
        agent.isStopped = true;
    }

    public void StartNavigation()
    {
        agent.isStopped = false;
    }

}
