using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float expiry_timer = 12.50f;
    public float expiry_time_on_floor = 12.50f;
    public float after_pick_up_expiry_time = 0f;
    public bool is_pick_up = false;
    public bool is_expiry_timer_change_after_pick_up = false;
    public item_type our_item = item_type.pizza_box;
    public Quaternion originalRotationValue;
    public Transform originalValue;


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
        originalValue = this.gameObject.transform;
        originalRotationValue = transform.rotation;
        expiry_timer = expiry_time_on_floor;
       // StartCoroutine(ExpiryItem(expiry_timer));
    }

    // Update is called once per frame
    void Update()
    {
        if (is_expiry_timer_change_after_pick_up == false)
        {
            // items on the floor
            if (expiry_timer > 0 && is_pick_up == false)
            {
                expiry_timer -= Time.deltaTime;
            }// remove destory if the player doesn't pick up in time
            else if (expiry_timer < 0 && is_pick_up == false)
            {
                Destroy(this.gameObject);
            }
            else if (expiry_timer > 0 && is_pick_up == true) 
            {
                is_expiry_timer_change_after_pick_up = true;
                StartCoroutine(ExpiryItemWhileCarried(after_pick_up_expiry_time));
            }
        }
        
    }

    IEnumerator ExpiryItemWhileCarried(float timer)
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
    public void ResetOurRotation()
    {
        transform.rotation = originalRotationValue;
        transform.localScale = originalValue.localScale;
    }
}
public enum item_type
{
    pizza_box,
    milk,
    hambuger
}