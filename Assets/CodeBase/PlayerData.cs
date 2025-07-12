using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 Position;
    public int Health;
    public PlayerData(Vector3 position,int health)
    {
        Position = position;
        Health = health;
    }
}
