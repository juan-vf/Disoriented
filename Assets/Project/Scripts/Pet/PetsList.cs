using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsList : MonoBehaviour
{
    private static PetsList _current;
    [SerializeField] private List<Pet> _pets = new List<Pet>();
    private void Awake()
    {
        _current = this;
    }
    private void Start()
    {
    }
    public static PetsList GetCurrent { get { return _current; } }
    public List<Pet> GetPets { get { return _pets; } }
    public Pet GetPetById(int id)
    {
        foreach (Pet pet in _pets)
        {
            if(pet.GetId == id){
                return pet;
            }
        }
        return null;
    }
}
