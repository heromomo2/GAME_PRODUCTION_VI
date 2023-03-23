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
    public InventorySysterm(int Size) // the constructor that sets the amount of slots
    {
        inventorySlots = new List<InventorySlot>(Size);
        for(int i = 0; i < Size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }
    public bool AddToInventory(InventoryItemdata itemToAdd, int amountToAdd)
    {
        //inventorySlots[0] = new InventorySlot (itemToAdd, amountToAdd);
        //return true;
        if (Containsitems(itemToAdd, out List<InventorySlot> invSlot))// check whether item exists in inventory
        {
            foreach (var slot in invSlot)
            {
                if (slot.EnoughRoomLeftInStack(amountToAdd)) 
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotsChanged?.Invoke(slot);
                    return true;
                }
            }
           
        }
        if (HasFreeSlot(out InventorySlot freeslot))// gets the first available slot
        {
            if (freeslot.EnoughRoomLeftInStack(amountToAdd))
            {
                freeslot.UpdateInventorySlot(itemToAdd, amountToAdd);
                OnInventorySlotsChanged?.Invoke(freeslot);
                return true;
            }
            // add implemetation to only take what can fill the stack, and check for another free slot to put the reminder in.
        }

        return false;
    }

    public bool Containsitems(InventoryItemdata itemToAdd, out List<InventorySlot> invslot)// do any of our slots have the item to add in them?
    {
        invslot = inventorySlots.Where(i => i.Itemdata == itemToAdd).ToList(); // if they do, if not return false.
      
        return invslot.Count > 1 ? true: false;// If they do return true, if not return false.
    }

    public bool HasFreeSlot(out  InventorySlot freeSlot) 
    {
        

        freeSlot = inventorySlots.FirstOrDefault(i => i.Itemdata == null);// fet the first free slot
        return freeSlot == null ?  false: true;

    }
}
