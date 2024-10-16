using System;
using UnityEngine;

public class LinternController : MonoBehaviour
{
    [SerializeField] private PistasController _pistasController;
    [SerializeField] private GameObject Lintern;
    private bool linternON = false; // esto establece que la linterna sea utilizable
    private bool linternActive = false; // esto establece que la linterna esté encendida o apagada


    private void Start()
    {
        
    }

    public void LinternOnOff()
    {
        if (_pistasController.ClueslinternFind())
        {
            linternON = true;
            Debug.Log("Linterna Activada");


        }
    }
    private void Update()
    {
        if (linternON == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (linternActive == false)
                {
                    linternActive = true;
                    Lintern.SetActive(true);
                }
                else if (linternActive == true)
                {
                    linternActive = false;
                    Lintern.SetActive(false);
                }
            }
        }
    }


}
