using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventorySlot 
{
    [SerializeField] private InventoryItemdata item_data;
    [SerializeField] private int stack_size;


    public InventoryItemdata Itemdata => item_data;
    public int StackSize => stack_size;


    public InventorySlot( InventoryItemdata source, int amount) 
    {
        item_data = source;
        stack_size = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public bool  RoomLeftInStack( int amountToAdd, out int amountRemaining)
    {
        amountRemaining = item_data.max_stack_size;
        return RoomLeftInStack(amountToAdd);
    }
    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stack_size + amountToAdd <= item_data.max_stack_size) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ClearSlot() 
    {
        item_data = null;
        stack_size = -1;
    }
    public void AssignItem( InventorySlot invslot)
    { 
        if( item_data == invslot.Itemdata) 
        {
            AddToStack(invslot.stack_size);
        }
        else 
        {
            item_data = invslot.item_data;
            stack_size = 0;
            AddToStack(invslot.stack_size);
        }
    }
    public void UpdateInventorySlot(InventoryItemdata data, int amount) 
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
        if(stack_size <= 1) 
        {
            splitStack = null;
            return false;
        }
        int halfStack = Mathf.RoundToInt(stack_size/2);
        RemoveFromStack(halfStack);
        splitStack = new InventorySlot(item_data, halfStack);
        return true;
    }
}
