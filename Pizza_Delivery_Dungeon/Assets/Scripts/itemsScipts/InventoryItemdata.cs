using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Inventory System/Inventory Item")]
public class InventoryItemdata : ScriptableObject
{
    public int ID;
    public string display_name;
    [TextArea(4, 4)]
    public string description;
    public string duration;
    public string money_gain;
    public Sprite icon;
    public int max_stack_size;

    
}
