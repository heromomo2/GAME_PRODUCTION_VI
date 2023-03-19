using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventoryholder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySysterm inventorySysterm;


    public InventorySysterm InventorySysterm => inventorySysterm;

    public static UnityAction<InventorySysterm> OnDynamicInventoryDisplayeRequested;

    private void Awake() 
    {
        inventorySysterm = new InventorySysterm(inventorySize);
    }
 
}
