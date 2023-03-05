using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerChildObjectCollsion : MonoBehaviour
{
    public Boxhandle player_boxhandle;

    public PlayerEvent player_event;



    public ThirdPersonController player_3rd_person_controller;
    // Start is called before the first frame update


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision->" + collision.gameObject.name);
        if (collision.gameObject.tag == "Pizzabox" || collision.gameObject.tag == "Item")
        {
            if (this.gameObject.tag == "PlayerChild")
            {
                if (player_boxhandle != null)
                {
                    player_3rd_person_controller.is_player_overlap_pizza = true;

                    if (player_3rd_person_controller.is_player_carry != true)
                    {
                        player_boxhandle.AttendCarriedItemToPlayer(collision.gameObject);
                    }
                }
            }
        }


    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Pizzabox")
        {
            if (this.gameObject.tag == "PlayerChild")
            {
                player_3rd_person_controller.is_player_overlap_pizza = false;
            }
        }
    }

    /// <summary>
    ///  trap
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "trapspike")
        {
            if (this.gameObject.tag == "PlayerChild")
            {
                /// check for the player if they have an item
                if (player_event.GetComponent<ThirdPersonController>() != null) 
                {
                    ThirdPersonController player_3rd_person_controller = player_event.GetComponent<ThirdPersonController>();
                    if (player_3rd_person_controller.is_player_carry == true  && player_3rd_person_controller.Invincible == false)
                    {
                        // tell the ordersystm that lost the item
                        player_event.PlayerGotSpike();

                        Debug.Log("Player got impale by spike trap");
                    }
                }

            }
        }


    } 
}
