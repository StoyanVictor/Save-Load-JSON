using UnityEngine;
public class ItemBase : ScriptableObject,IItem
{
    public string id;
    public Sprite icon;
    public bool canBeDropped;
    public string Id() => id;
    public Sprite Icon() => icon;
    public bool CanBeDropped() => canBeDropped;
}
public interface IItem
{
    public string Id();
    public Sprite Icon();
    public bool CanBeDropped();
}
