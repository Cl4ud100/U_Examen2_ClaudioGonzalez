using System;
using System.Collections;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [Header("Danger and Health")]
    [Tooltip("Todo lo referente a daño al jugador y su vida")]
    [SerializeField] private GameObject dangerzone;
    private Collider _dangerzonecollider;
    [SerializeField] private int health = 100;
    [SerializeField] private int decreaseHealth = 10;

    [Space] 
    
    [Header("UI")] 
    [Tooltip("Estas son las UI")]
    [SerializeField] private GameObject dangerzoneUI;
    [SerializeField] private GameObject gameOverUI;

    [Space]
    [Header("Camaras")] 
    [Tooltip("Variables de la camara")]
    [SerializeField] private CinemachineVirtualCamera fpCamara;
    [SerializeField] private CinemachineVirtualCamera secondCamara;

    private Coroutine dangerZoneCoroutine;
    
    
    
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
            {
                if (dangerZoneCoroutine == null)
                {
                    dangerZoneCoroutine = StartCoroutine(DangerZoneDamage());
                }
                
            }
                break;
                
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Danger":
            {
                if (dangerZoneCoroutine != null)
                {
                    StopCoroutine(dangerZoneCoroutine);
                    dangerZoneCoroutine = null;
                }

                dangerzoneUI.SetActive(false);
                break;
            }
        }
    }

    IEnumerator DangerZoneDamage()
    {
        while (health >= 0)
        {
            health -= decreaseHealth;
            dangerzoneUI.SetActive(true);
            Debug.Log("daño recibido");
            //Invoke("SwitchToNewCamera",100);
            yield return new WaitForSeconds(0.5f);
            dangerzoneUI.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        if (health <= 0)
        {
            //Invoke("SwitchTofpCamera",20);
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    private void SwitchToNewCamera()
    {
        fpCamara.Priority = 0;
        secondCamara.Priority = 10;
    }

    private void SwitchTofpCamera()
    {
        secondCamara.Priority = 0;
        fpCamara.Priority = 10;
    }
}

