using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{
    public DynamicInventoryDisplay InventoryPanel;



    private void Awake()
    {
        InventoryPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
       Inventoryholder.OnDynamicInventoryDisplayeRequested += DisplayInventory;   
    }
    private void OnDisable()
    {
        Inventoryholder.OnDynamicInventoryDisplayeRequested -= DisplayInventory;
    }


    void DisplayInventory( InventorySysterm invToDisplay) 
    {
        InventoryPanel.gameObject.SetActive(true);
        InventoryPanel.RefreshDynamicInventory(invToDisplay);
    }
    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.bKey.wasPressedThisFrame) 
        //{
        //    DisplayInventory(new InventorySysterm(Random.RandomRange(1,3)));
        //}
        if (InventoryPanel.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame) 
        {
            InventoryPanel.gameObject.SetActive(false);
        }
    }
}
