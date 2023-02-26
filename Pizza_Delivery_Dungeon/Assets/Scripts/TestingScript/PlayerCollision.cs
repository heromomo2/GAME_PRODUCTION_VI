using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;



public class PlayerCollision : MonoBehaviour
{
    public Boxhandle player_boxhandle;



    public ThirdPersonController player_3rd_person_controller;
   

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Debug.Log("hit->" + hit.gameObject.name);
        if (hit.gameObject.tag =="Pizzabox")
        {
            if (this.gameObject.tag == "Player")
            {
                if (player_boxhandle != null)
                {
                    player_3rd_person_controller.is_player_overlap_pizza = true;

                    if (player_3rd_person_controller.is_player_carry != true)
                    {
                        player_boxhandle.AttendCarriedItemToPlayer(hit.gameObject);
                    }
                }
            }
        }
        else
        {
            player_3rd_person_controller.is_player_overlap_pizza = false;
        }
       
    }

}

