using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [Header("floor vars")]
    public float expiry_timer_while_on_floor = 12.50f;
    public float expiry_time_on_floor = 12.50f;


    [Header("pickedup vars")]

    public float after_pick_up_expiry_time = 0f;
    public float expiry_timer_while_carry_item = 0f;
    public bool is_pick_up = false;
    public bool is_expiry_timer_change_after_pick_up = false;

    [Header("items Particle")]

    public GameObject pick_up_particle;
    public GameObject fail_particle;

    [Header("items general")]
    public item_type our_item = item_type.pizza_box;




    // Transform initial_spawn position;

    private Action<int> pick_up_item_event = null;
    public event Action<int> On_pick_up_item_event
    {
        add
        {
            pick_up_item_event -= value;
            pick_up_item_event += value;
        }

        remove
        {
            pick_up_item_event -= value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        expiry_timer_while_on_floor = expiry_time_on_floor;

        if (pick_up_particle != null)
        {
            pick_up_particle.SetActive(false);
        }
        if (fail_particle != null)
        {
            fail_particle.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_expiry_timer_change_after_pick_up == false)
        {
            // items on the floor
            if (expiry_timer_while_on_floor > 0 && is_pick_up == false)
            {
                expiry_timer_while_on_floor -= Time.deltaTime;
            }// remove destory if the player doesn't pick up in time
            else if (expiry_timer_while_on_floor < 0 && is_pick_up == false)
            {
                Destroy(this.gameObject);
            }
            else if (expiry_timer_while_on_floor > 0 && is_pick_up == true)
            {
                is_expiry_timer_change_after_pick_up = true;

                // set up the timer for the player after pick up the item
                if (after_pick_up_expiry_time > 0)
                {
                    expiry_timer_while_carry_item = after_pick_up_expiry_time;
                }

            }
        }
        else
        {
            // the player pick up the item 
            // we count down before it  expiry
            if (expiry_timer_while_carry_item > 0)
            {
                expiry_timer_while_carry_item -= Time.deltaTime;
            }
            else
            {
                if (is_pick_up == true)
                {
                    if (pick_up_item_event != null)
                    {
                        pick_up_item_event(1);
                    }
                }
                Destroy(this.gameObject);
            }

        }

    }

    public  void PlayPickUpParticle() 
    {
        if( pick_up_particle != null)
        {
            pick_up_particle.SetActive(true);
        }
    }
    void PlayFailParticle()
    {
        if (fail_particle != null)
        {
            fail_particle.SetActive(true);
        }
    }

}
public enum item_type
{
    pizza_box,
    milk,
    hambuger
}