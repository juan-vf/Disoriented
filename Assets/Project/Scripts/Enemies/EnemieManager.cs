using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieManager : MonoBehaviour
{
    private NavMeshController _enemieNavMeshController;
    private FieldOfView _fieldOfView;
    // Start is called before the first frame update
    void Start()
    {
        _enemieNavMeshController = GetComponent<NavMeshController>();
        _fieldOfView = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public NavMeshController GetNavMeshController{get{return _enemieNavMeshController;}}
    public FieldOfView GetFieldOfView{get{return _fieldOfView;}}
}
