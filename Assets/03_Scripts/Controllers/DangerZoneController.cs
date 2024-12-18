using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private GameObject dangerzoneUI;
    [SerializeField] private int HealthDecreased = 10;
    private IEnumerator InstanciaDanger;

    private void Start()
    {
        InstanciaDanger = dangerzonefire();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(InstanciaDanger);
        }
    }

    IEnumerator dangerzonefire()
    {
        while (GameManage.instance.health >= 0)
        {
            dangerzoneUI.SetActive(true);
            GameManage.instance.decreasedHealth(HealthDecreased);
            Debug.Log("Se te ha restado " + HealthDecreased);
            yield return new WaitForSeconds(1);
            dangerzoneUI.SetActive(false);
            yield return new WaitForSeconds(1);
        }

        if (GameManage.instance.health <= 0)
        {
            SceneManager.LoadScene("GameOver");
            
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        dangerzoneUI.SetActive(false);
        StopCoroutine(InstanciaDanger);
    }
}
