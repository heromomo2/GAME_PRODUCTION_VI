using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ChestInventory : Inventoryholder, IInteractable
{
    public UnityAction<IInteractable> OnInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool InteractSuccessfull)
    {
        OnDynamicInventoryDisplayeRequested?.Invoke(inventorySysterm);
        InteractSuccessfull = true;
    }
    public void EndInteraction() 
    {

    }
}
