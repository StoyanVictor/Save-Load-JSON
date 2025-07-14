using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerData : IData
{
    public Vector3 Position;
    public int Health;
    public int Money;
    public PlayerData(Vector3 position,int health,int money)
    {
        Position = position;
        Health = health;
        Money = money;
    }
}
[Serializable]
public class InventoryData : IData
{
    public List<string> ItemsId = new List<string>();
    public InventoryData(List<string> ids)
    {
        ItemsId = ids;
    }
}

public interface IData
{
}