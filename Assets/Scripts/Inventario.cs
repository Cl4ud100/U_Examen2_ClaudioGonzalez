using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<Items> listaItem = new List<Items>();
    
    //Referencia al Panel del inventario
    public GameObject inventarioPanel;
    
    //Referencia al Prefab Creado para la imagen del item
    public GameObject inventarioItemPrefab;
    
    //estado del inventario
    private bool inventarioVisible = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventarioVisible = !inventarioVisible;
            inventarioPanel.SetActive(inventarioVisible);
        }
    }

    public void AddItem(Items items)
    {
        listaItem.Add(items);
        Debug.Log(items._nombreItem + "agregado");
        UpdateInventarioUI();
    }

    public bool HasItem(string nombreItem)
    {
        foreach (Items items in listaItem)
        {
            if (items._nombreItem == nombreItem)
            {
                return true;
            }
        }

        return false;
    }

    private void UpdateInventarioUI()
    {
        //limpieza de items actuales
        foreach (Transform child in inventarioPanel.transform)
        {
            Destroy(child.gameObject);
        }
        
        //Con esto crearemos el objeto dentro del inventario
        foreach (Items item in listaItem)
        {
            //instanciamos el prefab creado para conseguir crear un gameobject y obtener la instancia
            GameObject itemUI = Instantiate(inventarioItemPrefab, inventarioPanel.transform);
            //Esto hara aparecer el nombre del objeto recogido
            TextMeshProUGUI nombreobjeto = itemUI.transform.Find("NameItemText").GetComponent<TextMeshProUGUI>();
            nombreobjeto.text = item._nombreItem;
            
            //esto configurara la imagen que se presentara en el panel
            Image iconItem = itemUI.GetComponent<Image>();
            iconItem.sprite = item._spriteItem;
        }
    }

}
