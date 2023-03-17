using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventorySlot 
{
    [SerializeField] private InventoryItemdata item_data; // Reference to the data
    [SerializeField] private int stack_size;// Current Stack size - how many of the data do we have?


    public InventoryItemdata Itemdata => item_data;
    public int StackSize => stack_size;


    public InventorySlot( InventoryItemdata source, int amount) // constructor to make occupied inventory slot.
    {
        item_data = source;
        stack_size = amount;
    }

    public InventorySlot()// Constructor to make an empty invetory slot.
    {
        ClearSlot();
    }

    public bool  EnoughRoomLeftInStack( int amountToAdd, out int amountRemaining)// would the enough room in the stack for the amount we're trying to add.
    {
        amountRemaining = item_data.max_stack_size;
        return EnoughRoomLeftInStack(amountToAdd);
    }
    public bool EnoughRoomLeftInStack(int amountToAdd)
    {
        if (item_data == null || Itemdata != null && stack_size + amountToAdd <= item_data.max_stack_size) 
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void ClearSlot()  // clears the slot
    {
        item_data = null;
        stack_size = -1;
    }
    public void AssignItem( InventorySlot invslot)// Assigns an item to the slot
    { 
        if( item_data == invslot.Itemdata)  //Does the slot contain the same item? Add to stack if so.
        {
            AddToStack(invslot.stack_size);
        }
        else // Overwrite slot with the inventory slot that we're passing in.
        {
            item_data = invslot.item_data;
            stack_size = 0;
            AddToStack(invslot.stack_size);
        }
    }
    public void UpdateInventorySlot(InventoryItemdata data, int amount) //Update slot directly
    {
        item_data = data;
        stack_size = amount;
    }
    public void AddToStack(int amount) 
    {
        stack_size += amount;      
    }
    public void RemoveFromStack(int amount)
    {
        stack_size -= amount;
    }
    public bool SplitStack(out InventorySlot splitStack) 
    {
        if(stack_size <= 1)  // Is there enough to actually split? If not return false.
        {
            splitStack = null;
            return false;
        }
        int halfStack = Mathf.RoundToInt(stack_size/2); // Get half the stack.
        RemoveFromStack(halfStack);

        splitStack = new InventorySlot(item_data, halfStack);// Creates a copy of this slot with half the stack size.
        return true;
    }
}
