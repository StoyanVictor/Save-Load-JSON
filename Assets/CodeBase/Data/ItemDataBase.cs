using System.Collections.Generic;
using CodeBase;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/ItemsDataBase")]
public class ItemDataBase : ScriptableObject
{
    public List<Item> items = new List<Item>();
    public Dictionary<string,Item> ItemsKeys = new Dictionary<string,Item>();
    public void InitializeItemDataBase()
    {
        foreach (var item in items)
        {
            ItemsKeys[item.Id()] = item;
        }
    }
    public Item GetItemById(string id)
    {
        return ItemsKeys[id];
    }

}
