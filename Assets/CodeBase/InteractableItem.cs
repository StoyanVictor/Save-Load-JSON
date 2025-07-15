using CodeBase;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private Item _item;
    public ItemBase GetItem()
    {
        return _item;
    }
}