using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu( menuName = " Events / Grab ")]
public class GrabEventManager : ScriptableObject
{
    //MOCHILA
    //AGARRAR MASCOTA
    //Lanza el que la agarra y lo escucha la mascota
    public UnityAction<int> onGrabPet;
    public void GrabPet(int value){onGrabPet?.Invoke(value);}
    //INSTANCIAR MASCOTA
    //Lanza la mascota y lo escucha (Noah o el Enemigo)
    public UnityAction<int, int> onSendPetToListener;
    public void SendPetToListener(int id, int serialId){onSendPetToListener?.Invoke(id, serialId);}

    //(variacion de onSendPetToListener)Lanzada por el que la agarra y manda un id asi el que escucha verifica y TAMBIEN manda un transform para que sea hijo de  la mano por EJ.
    public UnityAction<int, Transform> onGrabPetInHand;
    public void GrabPetInHand(int id, Transform hand){onGrabPetInHand?.Invoke(id, hand);}
}
