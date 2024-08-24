using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recogerlinterna : MonoBehaviour
{
    // Esta es la referencia al jugador, puedes configurarla desde el inspector o encontrarla en el script.
    public GameObject player;

    // Distancia mínima para que el jugador pueda recoger el objeto.
    public float pickUpRange = 1.0f;

    // Identificador del objeto, puede ser útil si estás gestionando un inventario.
    public string linterna;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Comprobar la distancia entre el jugador y el objeto
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // Si la distancia es menor o igual a la distancia de recogida, permitir la recogida.
        if (distanceToPlayer <= pickUpRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }
    
    void PickUp()
    {
        // Aquí se agrega la lógica para añadir el objeto al inventario o simplemente destruir el objeto.
        Debug.Log("Has recogido: " + linterna);

        // Puedes añadir aquí el objeto al inventario del jugador si tienes un sistema de inventario.

        // Destruir el objeto después de recogerlo
        Destroy(gameObject);
    }

    // Esto se usa para mostrar un mensaje en pantalla cuando el jugador está cerca del objeto.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }
}
