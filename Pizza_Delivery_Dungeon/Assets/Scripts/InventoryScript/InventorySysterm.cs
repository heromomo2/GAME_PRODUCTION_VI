using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySysterm 
{

    [SerializeField] private List<InventorySlot> inventorySlots;

    public  List<InventorySlot> InventorySlots => inventorySlots;

    public int inventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotsChanged;
    public InventorySysterm(int Size) 
    {
        inventorySlots = new List<InventorySlot>(Size);
        for(int i = 0; i < Size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

}
