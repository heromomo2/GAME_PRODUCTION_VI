using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{
    [SerializeField] private Inventoryholder inventoryholder;
    [SerializeField] private InventorySlot_UI[] slots;
    protected override void Start()
    {
        base.Start();
        if (inventoryholder != null)
        {
            inventorySysterm = inventoryholder.InventorySysterm;
            inventorySysterm.OnInventorySlotsChanged += UpateSlot;
        }
        else Debug.LogWarning($"No Inventory assigned to {this.gameObject}");

        AssignSlot(inventorySysterm);
    }
    public override void AssignSlot(InventorySysterm invToDisPlay)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if (slots.Length != inventorySysterm.inventorySize) Debug.Log($"Inventory slot out of sync on {this.gameObject}");
        for (int i = 0; i < inventorySysterm.inventorySize; i++) 
        {
            slotDictionary.Add(slots[i],inventorySysterm.InventorySlots[i]);
            slots[i].Init(inventorySysterm.InventorySlots[i]);
        }
    }
}
