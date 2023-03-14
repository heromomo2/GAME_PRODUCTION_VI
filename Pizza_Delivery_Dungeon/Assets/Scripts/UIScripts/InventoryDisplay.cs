
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;
    protected InventorySysterm inventorySysterm;

    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;


    public InventorySysterm InventorySysterm => inventorySysterm;

    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start() 
    { 
    }

    public abstract void AssignSlot(InventorySysterm invToDisPlay);

    protected virtual void UpateSlot(InventorySlot updatedSlot) 
    {
        foreach(var slot in SlotDictionary) 
        {
            if (slot.Value == updatedSlot)  
            {
                slot.Key.UpdateUISlot(updatedSlot);
            }
        }
    }

    public void SlotClicked( InventorySlot_UI clickedSlot) 
    {
        Debug.Log("Slot clicked");
    }
}
