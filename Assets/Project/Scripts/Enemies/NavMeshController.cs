using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public float stopDistance;
    private Transform target;
    private NavMeshAgent _navMeshAgent;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    public void UpdateTargetDir(Vector3 dest){
        // Debug.Log("Nuevo destino: "+ dest);
        // navMeshAgent.SetDestination(dest);
        _navMeshAgent.destination = dest;
        _navMeshAgent.isStopped = false;
    }
    public void NavMeshStop(){
        _navMeshAgent.isStopped = true;
    }
    
    public void NavMeshGo(){
        _navMeshAgent.isStopped = false;
    }
    //ISARRIVED NO ANDA
    public bool IsArrived(){
        return _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_navMeshAgent.pathPending;
    }
    public void PursueTarget(){
        // Debug.Log("target"+target.tag + target.position);
        // Debug.Log("Persiguiendo");
        UpdateTargetDir(target.position);
    }
    public void SetStoppingDistance(float value){
        _navMeshAgent.stoppingDistance = value;
    }
    public void setTarget(Transform newTarget){
        target = newTarget;
    }
    public void SetSpeed(float speed){
        _navMeshAgent.speed = speed;
    }
    public void SetAgentValues(string speed = "", string angularSpeed = "", string acceleration = "", string stopDistance = ""){
        if(speed != "") _navMeshAgent.speed = float.Parse(speed);
        if(angularSpeed != "") _navMeshAgent.angularSpeed = float.Parse(angularSpeed);
        if(acceleration != "") _navMeshAgent.acceleration = float.Parse(acceleration);
       if(stopDistance != "") _navMeshAgent.stoppingDistance = float.Parse(stopDistance);
    }
    public NavMeshAgent GetNavMeshAgent{
        get{return _navMeshAgent;}
    }
}
