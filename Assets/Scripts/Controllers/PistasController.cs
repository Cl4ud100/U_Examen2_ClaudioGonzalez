using UnityEngine;

public class PistasController : MonoBehaviour
{
    [SerializeField] private bool battery;
    [SerializeField] private bool lintern;
    [SerializeField] private bool keydoor;
    [SerializeField] private LinternController _linternController;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Battery":
                battery = true;
                Debug.Log("Encontraste la bateria");
                _linternController.LinternOnOff();
                break;
            case "lintern":
                lintern = true;
                Debug.Log("Encontraste la linterna");
                _linternController.LinternOnOff();
                break;
            case "KeyDoor":
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
