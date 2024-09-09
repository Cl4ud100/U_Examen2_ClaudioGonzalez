using System;
using Unity.VisualScripting;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [Header("Danger and Health")]
    [Tooltip("Todo lo referente a daño al jugador y su vida")]
    [SerializeField] private GameObject dangerzone;
    private Collider _dangerzonecollider;
    [SerializeField] private int health = 100;
    [SerializeField] private int decreaseHealth = 5;

    [Space] [Header("UI")] 
    [Tooltip("Estas son las UI de vida y daño")]
    [SerializeField] private GameObject dangerzoneUI;
    
    
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
        switch (other.tag)
        {
            case "Danger":
                
        }
    }
}

