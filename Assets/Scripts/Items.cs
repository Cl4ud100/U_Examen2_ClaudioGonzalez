using UnityEngine;

[System.Serializable]
public class Items
{
    public string _nombreItem;
    public string _descripcionItem;
    public Sprite _spriteItem;

    public Items(string nombreItem, string descripcionItem, Sprite iconItem )
    {
        _nombreItem = nombreItem;
        _descripcionItem = descripcionItem;
        _spriteItem = iconItem;
    }
}
