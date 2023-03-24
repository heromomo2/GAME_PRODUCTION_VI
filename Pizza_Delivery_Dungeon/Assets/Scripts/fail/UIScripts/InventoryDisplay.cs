
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;
    protected InventorySysterm inventorySysterm;

    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary; // Pair up the UI slots with the system slots.


    public InventorySysterm InventorySysterm => inventorySysterm;

    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {
    }

    public abstract void AssignSlot(InventorySysterm invToDisPlay); // Implemented in the child classes.

    protected virtual void UpateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updatedSlot)// Slot value - the "Under the hood" Inventory slot.
            {
                slot.Key.UpdateUISlot(updatedSlot);// slot key - UI representation of the value.
            }
        }
    }

    public void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        bool isShiftPressed = Keyboard.current.leftShiftKey.isPressed;

        // Clicked slot has an item - mouse doesn't have an item- pick up that item.

        // Does the cliked slot have item data- does the mouse have no item data

        if (clickedUISlot.AssignedInventorySlot.Itemdata != null && mouseInventoryItem.AssignedInventorySlot.Itemdata == null)
        {
            // if player is holding shift key split the stack?
            if (isShiftPressed && clickedUISlot.AssignedInventorySlot.SplitStack(out InventorySlot halfstackSlot)) //split stack
            {
                mouseInventoryItem.UpdateMouseSlot(halfstackSlot);
                clickedUISlot.UpdateUISlot();
                return;

            }
            else// pick up the item in the clicked slot.
            {
                mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
                clickedUISlot.ClearSlot();
                return;
            }
        }
        // Clicked slot doesn't have  item- Mouse does have an item - place the mouse int the empty slot.

        if (clickedUISlot.AssignedInventorySlot.Itemdata == null && mouseInventoryItem.AssignedInventorySlot.Itemdata != null)
        {


            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
            return;
        }

        // is the slot stack size + mouse stack size > slot max stack size? if so, take from mouse.
        //If different items, them swap the items.

       
        if (clickedUISlot.AssignedInventorySlot.Itemdata != null && mouseInventoryItem.AssignedInventorySlot.Itemdata != null)
        {
            bool isSameItem = clickedUISlot.AssignedInventorySlot.Itemdata == mouseInventoryItem.AssignedInventorySlot.Itemdata;

            // both slots have the same? if so the comine them.
            if (isSameItem && clickedUISlot.AssignedInventorySlot.EnoughRoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize))
            {
                clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
                return;
            }
            else if (isSameItem && 
                !clickedUISlot.AssignedInventorySlot.EnoughRoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize, out int leftInStack)) 
            {
                if (leftInStack < 1) 
                {
                    SwapSlot(clickedUISlot); /// the stack is full so swap the items.
                }
                else // slot is not at max, so take what's need from the mouse inventory.
                {
                    int remainingOnMouse = mouseInventoryItem.AssignedInventorySlot.StackSize - leftInStack;

                    clickedUISlot.AssignedInventorySlot.AddToStack(leftInStack);
                    clickedUISlot.UpdateUISlot();

                    var newItem = new InventorySlot(mouseInventoryItem.AssignedInventorySlot.Itemdata,remainingOnMouse);
                    mouseInventoryItem.ClearSlot();
                    mouseInventoryItem.UpdateMouseSlot(newItem);
                    return;
                }
            }
            else if (!isSameItem)
            {
                SwapSlot(clickedUISlot);
                return;
            }
        }
        Debug.Log("Slot clicked");
    }
    private void SwapSlot(InventorySlot_UI clickedUISlot)
    {
        var clonedSlot = new InventorySlot(mouseInventoryItem.AssignedInventorySlot.Itemdata, mouseInventoryItem.AssignedInventorySlot.StackSize);
        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);

        clickedUISlot.ClearSlot();

        clickedUISlot.AssignedInventorySlot.AssignItem(clonedSlot);
        clickedUISlot.UpdateUISlot();
    }
}
