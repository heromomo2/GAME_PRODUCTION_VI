using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StarterAssets;
public class ChestInventory : Inventoryholder, IInteractable
{

    public UnityAction<IInteractable> OnInteractionComplete { get; set; }

    [SerializeField] private InventoryItemdata firsttest;
    [SerializeField] DynamicInventoryDisplay did;
    [SerializeField] public ThirdPersonController ThirdPerson;

    public void Interact(Interactor interactor, out bool InteractSuccessfull)
    {
        ThirdPerson.StopPlayerMovementWhileUI();
       
        OnDynamicInventoryDisplayeRequested?.Invoke(inventorySysterm);
       // test();
        InteractSuccessfull = true;
    }

    
    public void EndInteraction() 
    {
        ThirdPerson.AllowPlayerInputMovementOutUI();
    }
    
    void test() 
    {
        inventorySysterm.AddToInventory(firsttest, 1);
        did.RefreshDynamicInventory(inventorySysterm);
        did.AssignSlot(inventorySysterm);

    }


    void Update 
    { 
    }
}
