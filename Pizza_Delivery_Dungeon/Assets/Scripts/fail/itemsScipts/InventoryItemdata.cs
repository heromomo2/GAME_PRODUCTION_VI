using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this is a scriptable object, that defines what an item is in our game.
/// it's could inherited from to have branched version of items, for example potions and equipment.
/// </summary>
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
