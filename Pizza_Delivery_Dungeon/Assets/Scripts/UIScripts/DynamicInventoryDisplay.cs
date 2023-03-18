using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicInventoryDisplay : InventoryDisplay
{

    [SerializeField] protected InventorySlot_UI slotPrefab;
    protected override void Start()
    {
       // Inventoryholder.OnDynamicInventoryDisplayeRequested += RefreshDynamicInventory;
        base.Start();
        ///AssignSlot(inventorySysterm);
    }

    private void OnDestroy()
    {
        ///Inventoryholder.OnDynamicInventoryDisplayeRequested -= RefreshDynamicInventory;

    }

    public void RefreshDynamicInventory(InventorySysterm invToDisplay)
    {
        Cleanslot();
        inventorySysterm = invToDisplay;
        AssignSlot(invToDisplay);
    }
    public override void AssignSlot(InventorySysterm invToDisPlay)
    {
        Cleanslot();
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if (invToDisPlay == null)
        {
            return;
        }
        for (int i = 0; i < invToDisPlay.inventorySize; i++)
        {
            var UiSlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(UiSlot, invToDisPlay.InventorySlots[i]);
            UiSlot.Init(invToDisPlay.InventorySlots[i]);
            UiSlot.UpdateUISlot();
        }
    }

    private void Cleanslot() 
    {
        foreach(var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }
        if(slotDictionary != null)
        {
            slotDictionary.Clear();
        }
    }
}
