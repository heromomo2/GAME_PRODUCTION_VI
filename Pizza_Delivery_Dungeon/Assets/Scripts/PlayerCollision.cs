using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;



public class PlayerCollision : MonoBehaviour
{
    public Boxhandle player_boxhandle;



    public ThirdPersonController player_3rd_person_controller;
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("PizzaBox"))
    //    {
    //        if (this.gameObject.CompareTag("Player"))
    //        {
    //            if (player_boxhandle != null)
    //            {
    //                player_boxhandle.AttendPizzToPlayer(collision.gameObject);
    //            }

    //        }
    //    }
    //}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Pizzabox"))
        {
            if (this.gameObject.CompareTag("Player"))
            {
                if (player_boxhandle != null)
                {
                    player_3rd_person_controller.is_player_overlap_pizza = true;
                    if (player_3rd_person_controller.is_player_carry != true)
                    {
                        player_boxhandle.AttendPizzaToPlayer(hit.gameObject);
                    }
                }

            }
        }
        else
        {
            player_3rd_person_controller.is_player_overlap_pizza = false;
        }

        //if (hit.gameObject.CompareTag("DestinyLocationTrigger"))
        //{
        //    if (this.gameObject.CompareTag("Player"))
        //    {
        //        if (player_boxhandle != null)
        //        {
                   
        //            if (player_3rd_person_controller.is_player_carry == true)
        //            {
        //                player_boxhandle.RemovePizzaFromPlayer();
        //            }
        //        }

        //    }
        //}
       

    }

}

