using UnityEngine;

[System.Serializable]
public class Items
{
    public string _nombreItem;
    public string _descripcionItem;

    public Items(string nombreItem, string descripcionItem)
    {
        _nombreItem = nombreItem;
        _descripcionItem = descripcionItem;
    }
}
