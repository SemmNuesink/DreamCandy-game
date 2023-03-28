using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class navigation : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public bool freeRoam;
    public Vector3 roamLocation;
    private NavMeshHit hit;
    private RaycastHit rHit;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Vector3.Distance(target.position, new Vector3(0, 0, 0)) < 25f)
        {
            freeRoam = true;
        }
        

        if (Vector3.Distance(roamLocation, this.transform.position) <5)
        {
            do
            {
                roamLocation = new Vector3(Random.Range(-100, 100), 100, Random.Range(-100, 100));
                if (Physics.Raycast(roamLocation, Vector3.down, out rHit, 100))
                {
                    roamLocation = rHit.point;
                    if (CanReachPosition(roamLocation))
                    {
                        break;
                    }
                }
            } while (true);
        }

        
        if (freeRoam)
        {
            agent.SetDestination(roamLocation);
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }






    public bool CanReachPosition(Vector3 position)
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(position, path);
        return path.status == NavMeshPathStatus.PathComplete;
    }
}

