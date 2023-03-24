using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StarterAssets;
public class ChestInventory : Inventoryholder, IInteractable
{

    public UnityAction<IInteractable> OnInteractionComplete { get; set; }

    [SerializeField] private InventoryItemdata pizza_item_data;
    [SerializeField] private InventoryItemdata milk_item_data;
    [SerializeField] private InventoryItemdata burger_item_data;

    [SerializeField] DynamicInventoryDisplay dynamic_inventory_display;

    [SerializeField] public ThirdPersonController ThirdPerson;

    public void Interact(Interactor interactor, out bool InteractSuccessfull)
    {
        ThirdPerson.StopPlayerMovementWhileUI();
       
        OnDynamicInventoryDisplayeRequested?.Invoke(inventorySysterm);
        GenitemData();
        InteractSuccessfull = true;
    }

    
    public void EndInteraction() 
    {
        ThirdPerson.AllowPlayerInputMovementOutUI();
    }
    
    void GenitemData() 
    {


        inventorySysterm.AddToInventory(pizza_item_data, 1);
        dynamic_inventory_display.RefreshDynamicInventory(inventorySysterm);
        dynamic_inventory_display.AssignSlot(inventorySysterm);

    }


    void Update ()
    { 
    }
}
