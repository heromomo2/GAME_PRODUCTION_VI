using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    public InventorySlot AssignedInventorySlot;



    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }

    public void UpdateMouseSlot(InventorySlot invSlot) 
    {
        AssignedInventorySlot.AssignItem(invSlot);
        ItemSprite.sprite = invSlot.Itemdata.icon;
        ItemCount.text = invSlot.StackSize.ToString();
        ItemCount.color = Color.white;
    }

    private void Update()
    {
        if(AssignedInventorySlot.Itemdata != null) 
        {
            transform.position = Mouse.current.position.ReadValue();
            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointOverUIObject()) 
            {
                ClearSlot();
            }
        }
    }
    public void ClearSlot() 
    {
        AssignedInventorySlot.ClearSlot();
        ItemCount.text = "";
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }
    public static bool IsPointOverUIObject() 
    {
        PointerEventData eventdataCurrentPosition = new PointerEventData(EventSystem.current);
        eventdataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventdataCurrentPosition, results);
        return results.Count > 0;
    }
}