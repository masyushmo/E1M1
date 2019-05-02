using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Move_3p : MonoBehaviour
{
    private Transform target; // target to follow

    private NavMeshAgent agent; // ref to move agent
    
    public float JumpPower = 5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceToTarget();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * JumpPower;
        }
    }

    // move to point by coords
    public void MoveTo(Vector3 coords)
    {
        agent.SetDestination(coords);
    }

    // follow chosen target
    public void FollowTarget(InteractObj getTarget)
    {
        agent.stoppingDistance = getTarget.radius * .8f;
        agent.updateRotation = false;
        target = getTarget.obj;
    }

    // stop following target 
    public void StopFollow()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }
    
    // Rotate face of agent to following target
    void FaceToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }
}
