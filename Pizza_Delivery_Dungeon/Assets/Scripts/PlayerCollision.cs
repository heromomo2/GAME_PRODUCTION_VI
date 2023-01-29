using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public Boxhandle player_boxhandle;

    public GameObject player_3rd_person_controller;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PizzaBox"))
        {
            if (this.gameObject.CompareTag("Player"))
            {
                if (player_boxhandle != null) 
                {
                    player_boxhandle.AttendPizzToPlayer(collision.gameObject);
                }

            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
      if (hit.gameObject.CompareTag("Pizzabox"))
        {
            if (this.gameObject.CompareTag("Player"))
            {
                if (player_boxhandle != null)
                {
                    
                        player_boxhandle.AttendPizzToPlayer(hit.gameObject);
                        player_3rd_person_controller.GetComponent<Thi
                    
                }

            }
        }
    }

}
