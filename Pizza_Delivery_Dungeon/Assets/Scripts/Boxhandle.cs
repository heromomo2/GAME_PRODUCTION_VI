using StarterAssets;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
//using StarterAssets;

public class Boxhandle : MonoBehaviour
{
    // variable
    public GameObject carried_item;

    public Transform carry_point;

    public Transform carry_point_1;

    public int max_item_holded = 1;

    public int item_holded_counter = 0;


    public ThirdPersonController player_3rd_person_controller;

   

    /// <summary>
    /// attend the item to the player
    /// </summary>
    /// <param name="item"></param>
    public void AttendCarriedItemToPlayer(GameObject item)
    {
        if (player_3rd_person_controller.is_player_pick_up == true)
        {
            if (item.tag == "Pizzabox" || item.tag == "Item")
            {
                if (max_item_holded > item_holded_counter)
                {
                    item_holded_counter = item_holded_counter + 1;
                    item.transform.position = carry_point_1.transform.position;    //new Vector3 (item.transform.position.x, carry_point.transform.position.y + 0.2f, item.transform.position.z);
                    item.transform.parent = carry_point.transform;
                    player_3rd_person_controller.is_player_carry = true;
                    carried_item = item;
                    carried_item.GetComponent<PickUpItem>().is_pick_up = true;
                    carried_item.tag = "Untagged";
                    carried_item.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }


    /// <summary>
    /// remove the item when the player success
    /// </summary>
    public void RemoveCarriedItemFromPlayer( bool is_item_lost)
    {
        if (carried_item != null)
        {
            if (is_item_lost == true)
            {
                carried_item.GetComponent<PickUpItem>().DestoryExpicyItem();
            }
            else
            {
                Destroy(carried_item);
            }
            carried_item = null;
            player_3rd_person_controller.is_player_carry = false;
            player_3rd_person_controller.is_player_overlap_pizza = false;
            item_holded_counter = 0;
            
        }
        
    }


    /// <summary>
    /// remove the item  when  the player fails/
    /// this method just reset the player after the item was expires
    /// </summary>
    public void ResetPlayerAfterFailDelivery()
    {
        player_3rd_person_controller.is_player_carry = false;
        player_3rd_person_controller.is_player_overlap_pizza = false;
        item_holded_counter = 0;
    }

}
