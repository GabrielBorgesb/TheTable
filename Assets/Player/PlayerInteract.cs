using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInteract : MonoBehaviour
{
    

    public float interactRadius;
    public LayerMask interactLayer;
    public bool isOnTable;


    


    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    void CheckInteraction()
    {
        Collider[] chair = Physics.OverlapSphere(transform.position, interactRadius, interactLayer);
        

    }

}
