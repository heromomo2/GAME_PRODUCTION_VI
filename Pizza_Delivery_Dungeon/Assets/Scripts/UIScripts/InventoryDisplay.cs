
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

    public void SlotClicked( InventorySlot_UI clickedUISlot) 
    {  
        // Clicked slot has an item - mouse doesn't have an item- pick up that item.

        if (clickedUISlot.AssignedInventorySlot.Itemdata != null && mouseInventoryItem.AssignedInventorySlot.Itemdata == null) 
        {
            // if player is holding shift key split the stack?

            mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
            clickedUISlot.ClearSlot();
            return;
        }
        // Clicked slot doesn't have  item- Mouse does have an item - place the mouse int the empty slot.

        if (clickedUISlot.AssignedInventorySlot.Itemdata == null && mouseInventoryItem.AssignedInventorySlot.Itemdata != null)
        {


            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();
            mouseInventoryItem.ClearSlot();
            return;
        }
        // both slots have the same? if so the comine them.
        // is the slot stack size + mouse stack size > slot max stack size? if so, take from mouse.
        //If different items, them swap the items.
        Debug.Log("Slot clicked");
    }
}
