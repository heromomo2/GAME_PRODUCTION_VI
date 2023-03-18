using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicInventoryDisplay : InventoryDisplay
{

    [SerializeField] protected InventorySlot_UI slotPrefab;
    protected override void Start()
    {
        Inventoryholder.OnDynamicInventoryDisplayeRequested += RefeshDynamicInventory;
        base.Start();
    }

    private void OnDestroy()
    {
        Inventoryholder.OnDynamicInventoryDisplayeRequested -= RefeshDynamicInventory;

    }

    public void RefreshDynamicInventory(InventorySysterm invToDisplay)
    {
        inventorySysterm = invToDisplay;
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
