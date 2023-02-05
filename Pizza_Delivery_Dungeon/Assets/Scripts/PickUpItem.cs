using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float expiry_timer = 12.50f;
    public bool is_pick_up = false;
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
        if (our_item == item_type.pizza_box)
        {
             expiry_timer = 12.50f;
        }
        else if (our_item == item_type.milk)
        {
            expiry_timer = 7.0f;
        }
        //else if (our_item == item_type.hamburger) 
        //{
        //    expiry_timer = 30.50f;
        //}
        StartCoroutine(ExpiryItem(expiry_timer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExpiryItem(float timer)
    {
        yield return new WaitForSeconds(timer);
        if (is_pick_up == true)
        {
            if (pick_up_item_event != null)
            {
                pick_up_item_event(1);
            } 
        }
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        
    }
}
public enum item_type
{
    pizza_box,
    milk
}