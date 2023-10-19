
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsList : MonoBehaviour
{
    private static PetsList _current;
    [SerializeField] private List<Pet> _pets = new List<Pet>();
    private List<int> _serialIdList = new List<int>();
    private void Awake()
    {
        _current = this;
    }
    private void Start()
    {
    }
    public static PetsList GetCurrent { get { return _current; } }
    public int GetCount { get { return _pets.Count; } }
    public List<Pet> GetPets { get { return _pets; } }
    public List<int> GetSerialIdList { get { return _serialIdList; } }
    public Pet GetPetById(int id)
    {
        foreach (Pet pet in _pets)
        {
            if (pet.GetId == id)
            {
                return pet;
            }
        }
        return null;
    }
    public void AgregarNumeroUnico(List<int> lista)
    {
        int nuevoNumero;
        do
        {
            nuevoNumero = GenerarNumeroIdentificadorUnico();
        }
        while (lista.Contains(nuevoNumero));

        lista.Add(nuevoNumero);
    }
    private int GenerarNumeroIdentificadorUnico()
    {
        return Random.Range(1, 50);
    }
}
