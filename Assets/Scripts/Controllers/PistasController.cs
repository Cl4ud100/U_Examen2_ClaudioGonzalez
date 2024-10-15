using UnityEngine;

public class PistasController : MonoBehaviour
{
    private bool battery;
    private bool lintern;
    private bool keydoor;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Battery":
                battery = true;
                Debug.Log("Encontraste la bateria");
                break;
            case "lintern":
                lintern = true;
                Debug.Log("Encontraste la linterna");
                break;
            case "Key":
                keydoor = true;
                Debug.Log("Haz encontrado la llave de tus pesadillas");
                break;
        }
    }

    public bool ClueslinternFind()
    {
        return battery && lintern;
    }

    public bool CluesKeydoor()
    {
        return keydoor;
    }

}
