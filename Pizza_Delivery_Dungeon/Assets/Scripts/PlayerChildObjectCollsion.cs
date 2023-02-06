using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerChildObjectCollsion : MonoBehaviour
{
    public Boxhandle player_boxhandle;



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
}
