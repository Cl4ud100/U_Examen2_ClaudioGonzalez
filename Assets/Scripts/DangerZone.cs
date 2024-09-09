using System;
using Unity.VisualScripting;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [Header("Danger")]
    [Tooltip("Todo lo referente a daño al jugador")]
    [SerializeField] private GameObject dangerzone;
    private Collider dangerzonecollider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}

