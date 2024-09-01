using System;
using UnityEngine;

public class DoorPueblo : MonoBehaviour
{
    [Header("Door")] 
    [SerializeField] private bool openDoor;
    private Animator animDoor;
    [SerializeField] private GameObject Door;
    private Collider doorCollider;
    [SerializeField] private GameObject doorColliderGameObject;
    
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
            case "Door":
            {
                openDoor = true;
                animDoor.SetBool("AnimDoor",true);
                Debug.Log("Bienvenido a tus pesadillas");
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
