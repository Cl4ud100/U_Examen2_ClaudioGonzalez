using System;
using Unity.VisualScripting;
using UnityEngine;

public class BATERIASCRIPTS : MonoBehaviour
{
    private bool batteryFind = false;
    private bool linternFind = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         batteryFind = true;
    //         Debug.Log("Encontraste la bateria de la linterna");
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Battery":
                batteryFind = true;
                Debug.Log("Encontraste la bateria" + batteryFind);
                break;
            case "lintern":
                linternFind = true;
                Debug.Log("Encontraste la linterna" + linternFind);
                break;
        }
    }
}
