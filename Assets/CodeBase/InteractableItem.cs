using CodeBase;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private Item _item;
    public IItem GetItem()
    {
        return _item;
    }
}