using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public float stopDistance;
    private Transform target;
    private NavMeshAgent navMeshAgent;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    public void UpdateTargetDir(Vector3 dest){
        // Debug.Log("Nuevo destino: "+ dest);
        // navMeshAgent.SetDestination(dest);
        navMeshAgent.destination = dest;
        navMeshAgent.isStopped = false;
    }
    public void NavMeshStop(){
        navMeshAgent.isStopped = true;
    }
    
    public void NavMeshGo(){
        navMeshAgent.isStopped = false;
    }
    //ISARRIVED NO ANDA
    public bool IsArrived(){
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }
    public void PursueTarget(){
        Debug.Log("target"+target.tag + target.position);
        // Debug.Log("Persiguiendo");
        UpdateTargetDir(target.position);
    }
    public void setTarget(Transform newTarget){
        target = newTarget;
    }
    public NavMeshAgent GetNavMeshAgent{
        get{return navMeshAgent;}
    }
}
