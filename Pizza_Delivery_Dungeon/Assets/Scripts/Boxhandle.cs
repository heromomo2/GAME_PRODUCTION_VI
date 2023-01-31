using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Boxhandle : MonoBehaviour
{
    public GameObject carried_pizza_box;

    public Transform _holdpoint;


    public int max_pizza_holded = 1;
    public int pizza_holded_counter = 0;


    public ThirdPersonController player_3rd_person_controller;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {









    }


    public void AttendPizzaToPlayer(GameObject pizza)
    {
        if (player_3rd_person_controller.is_player_pick_up == true)
        {
            if (pizza.tag == "Pizzabox")
            {
                if (max_pizza_holded > pizza_holded_counter)
                {
                    pizza_holded_counter = pizza_holded_counter + 1;

                    // GameObject child_object = _holdpoint.gameObject;
                    pizza.transform.position = new Vector3(_holdpoint.transform.position.x, _holdpoint.transform.position.y + 0.2f, _holdpoint.transform.position.z);
                    pizza.transform.parent = _holdpoint.transform;
                    player_3rd_person_controller.is_player_carry = true;
                    carried_pizza_box = pizza;
                    carried_pizza_box.tag = "Untagged";
                }
            }
        }
    }

    public void RemovePizzaFromPlayer()
    {
        if (carried_pizza_box != null)
        {
            Destroy(carried_pizza_box);
            carried_pizza_box = null;
            player_3rd_person_controller.is_player_carry = false;
            player_3rd_person_controller.is_player_overlap_pizza = false;
            pizza_holded_counter = 0;
        }
    }
}
