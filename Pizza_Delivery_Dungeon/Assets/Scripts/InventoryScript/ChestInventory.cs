using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ChestInventory : Inventoryholder, IInteractable
{

    public UnityAction<IInteractable> OnInteractionComplete { get; set; }

    [SerializeField] private InventoryItemdata firsttest;
    [SerializeField] DynamicInventoryDisplay did;

    public void Interact(Interactor interactor, out bool InteractSuccessfull)
    {
       
        OnDynamicInventoryDisplayeRequested?.Invoke(inventorySysterm);
        test();
        InteractSuccessfull = true;
    }
    public void EndInteraction() 
    {
       
    }
    
    void test() 
    {
        inventorySysterm.AddToInventory(firsttest, 1);
        did.RefreshDynamicInventory(inventorySysterm);
        did.AssignSlot(inventorySysterm);

    }
}
