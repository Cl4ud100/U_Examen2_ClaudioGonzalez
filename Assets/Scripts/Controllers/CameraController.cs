using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camaras")] 
    [Tooltip("Variables de la camara")]
    [SerializeField] private CinemachineVirtualCamera fpCamara;
    [SerializeField] private CinemachineVirtualCamera secondCamara;
    
    public void SwitchToNewCamera()
    {
        fpCamara.Priority = 0;
        secondCamara.Priority = 10;
    }
    
    public void SwitchTofpCamera()
    {
        secondCamara.Priority = 0;
        fpCamara.Priority = 10;
    }
}
