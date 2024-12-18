using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private PistasController _pistasController;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private GameObject doorAnimacionGO;
    [SerializeField] private GameObject doorColisionGO;
    private Collider doorColision;
    private Animator doorAnimacion;

    private void Start()
    {
        doorColision = doorColisionGO.GetComponent<Collider>();
        doorAnimacion = doorAnimacionGO.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_pistasController.CluesKeydoor())
        {
            doorAnimacion.SetBool("AnimDoor",true);
            _cameraController.SwitchToNewCamera();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimacion.SetBool("AnimDoor",false);
        doorColision.enabled = false;
        _cameraController.SwitchTofpCamera();
    }
    
    
}
