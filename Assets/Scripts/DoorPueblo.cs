using System;
using Unity.VisualScripting;
using UnityEngine;

public class DoorPueblo : MonoBehaviour
{
    [Header("Door")] 
    [Tooltip("Esto tiene que ver con la puerta, no mover")]
    [SerializeField] private bool openDoor;
    private Animator animDoor;
    [SerializeField] private GameObject Door;
    private Collider doorCollider;
    [SerializeField] private GameObject doorColliderGameObject;

    [Header("Key")]
    [Tooltip("Condiciones para la llave")] 
    [SerializeField] private GameObject Key;
    private bool keyDoorVillage;
    private Collider keyCollider;
    [SerializeField] private GameObject keyColliderGameObject;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animDoor = Door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "KeyDoor":
            {
                keyDoorVillage = true;
                Debug.Log("Conseguiste la llave del pueblo");
                break;
            }
            
            case "Door":
            {
                if (keyDoorVillage)
                {
                    openDoor = true;
                    /*openDoor = !openDoor;*/
                    animDoor.SetBool("AnimDoor",true);
                    /*if (openDoor)
                    {
                        Debug.Log("La puerta esta abierta, Bienvenido a tus pesadillas");
                    }
                    else
                    {
                        Debug.Log("Puerta Cerrada, Busca la llave");
                    }*/
                    
                    
                }
                else
                {
                    Debug.Log("Ve a tomar la llave");
                }
                break;
                
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Door":
            {
                animDoor.SetBool("AnimDoor",false);
                break;
            }
            
        }
    }
}
