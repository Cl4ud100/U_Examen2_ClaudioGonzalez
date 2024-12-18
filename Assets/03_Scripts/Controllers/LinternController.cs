using UnityEngine;

public class LinternController : MonoBehaviour
{
    [SerializeField] private PistasController _pistasController;
    [SerializeField] private Light linternLight;
    private bool linternLightActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_pistasController.ClueslinternFind())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                linternLightActive = !linternLightActive;
                linternLight.gameObject.SetActive(linternLightActive);
            }
            Debug.Log("tengo las cosas");
        }
    }
}
