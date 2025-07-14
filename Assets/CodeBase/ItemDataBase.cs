using System.Collections.Generic;
using CodeBase;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/ItemsDataBase")]
public class ItemDataBase : ScriptableObject
{
    public List<Item> items = new List<Item>();
}
