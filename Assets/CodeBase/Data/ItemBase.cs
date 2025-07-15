using UnityEngine;
public class ItemBase : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool canBeDropped;
    [SerializeField] private GameObject prefab;
    public string Id() => id;
    public Sprite Icon() => icon;
    public bool CanBeDropped() => canBeDropped;
    public GameObject GetPrefab() => prefab;
}

