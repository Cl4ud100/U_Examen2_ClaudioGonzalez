using System;
using UnityEngine;

public class PistasController : MonoBehaviour
{
    [SerializeField] private bool battery;
    [SerializeField] private bool lintern;
    [SerializeField] private bool keydoor;
    private Inventario playerInventario;
    
    [SerializeField] private Sprite pista1;
    [SerializeField] private Sprite pista2;
    [SerializeField] private Sprite llave1;

    private void Start()
    {
        playerInventario = GetComponent<Inventario>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Battery":
                battery = true;
                Debug.Log("Encontraste la bateria");
                Items bateria = new Items("Pilas", "activar linterna",pista1);
                playerInventario.AddItem(bateria);
                Destroy(other.transform.parent.gameObject);
                break;
            case "lintern":
                lintern = true;
                Debug.Log("Encontraste la linterna");
                Items linterna = new Items("Linterna", "Puedes ver por su luz",pista2);
                playerInventario.AddItem(linterna);
                Destroy(other.transform.parent.gameObject);
                break;
            case "KeyDoor":
                keydoor = true;
                Items llave = new Items("Llave porton", "abriras puertas",llave1);
                playerInventario.AddItem(llave);
                Destroy(other.transform.parent.gameObject);
                Debug.Log("Haz encontrado la llave de tus pesadillas");
                break;
        }
    }

    public bool ClueslinternFind()
    {
        bool hasbattery = playerInventario.HasItem("bateria");
        bool hasLintern = playerInventario.HasItem("Linterna");
        return battery && lintern;
        
    }

    public bool CluesKeydoor()
    {
        bool haskeydoor = playerInventario.HasItem("Llave");
        return keydoor;
    }

}
