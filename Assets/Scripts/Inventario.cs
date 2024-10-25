using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<Items> listaItem = new List<Items>();

    public void AddItem(Items items)
    {
        listaItem.Add(items);
        Debug.Log(items._nombreItem + "agregado");
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

}
