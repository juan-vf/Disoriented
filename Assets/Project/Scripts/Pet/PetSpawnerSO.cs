using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = " Pets / SpawnerManager ")]
public class PetSpawnerSO : ScriptableObject
{
    private List<GameObject> _petPositions;
    private SimpleEvent _enemyRequest;
    public void Suscribe(){
        _enemyRequest.OnLaunchSimpleEvent += SendPet;

    }

    public void AddPets(GameObject obj){
        _petPositions.Add(obj);
    }
    public void DeleteById(int id){
        // _petPositions.Remove();
    }
    void SendPet(){
        
    }



}
