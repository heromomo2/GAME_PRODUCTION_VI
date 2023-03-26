using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using UnityEngine.InputSystem;

public class benchpart : MonoBehaviour
{
    [Header("item")]
    public GameObject prefabMilk;
    public GameObject prefabBurger;
    public GameObject prefabPizza;


    [Header("display item")]
    public Transform point_of_display;
    public List<GameObject> display_item_list;


    /// <summary>
    /// 
    /// </summary>
    public GameObject choseitem;
    public bool do_we_have_an_item = false;
  


    [Header("worldCavan")]
    public GameObject our_world_canvas;
    public Image backgroundimage;
    public Text name_of_item_text;
    public Text expicy_text;
    public Text money_text;
    public Text e_text;


    [Header("Trigger")]
    public BoxCollider our_box_collider;


    private Action<int> bench_part_event = null;

    public event Action<int> On_bench_part_event
    {
        add
        {
            bench_part_event -= value;
            bench_part_event += value;
        }

        remove
        {
            bench_part_event -= value;
        }
    }

    private void Start()
    {
        init();
    }
    void init()
    {
        /// place them int the right positon
        /// set to invisble
        
        if (display_item_list != null && display_item_list.Count > 0)
        {
            foreach (GameObject d in display_item_list)
            {
                d.transform.position = point_of_display.position;
                d.SetActive(false);
            }
        }

        if (our_world_canvas != null)
        {
            our_world_canvas.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);
        }
        DisplayItemOnTop(item_type.hambuger);
        ChangeWorldCavan();
        do_we_have_an_item = true;
    }

    void DisplayItemOnTop(item_type item_display)
    {
        if (display_item_list != null && display_item_list.Count > 0)
        {
            foreach (GameObject d in display_item_list)
            {
                if (item_display == d.GetComponent<displayItem>().our_item_type)
                {
                    d.SetActive(true);
                }
            }
        }
    }
    void hideItemOnTop()
    {
        if (display_item_list != null && display_item_list.Count > 0)
        {
            foreach (GameObject d in display_item_list)
            {
                
                    d.SetActive(false);
                
            }
        }
    }
    #region UI(world space)
    void ChangeWorldCavan()
    {
        if (name_of_item_text != null)
        {
            name_of_item_text.text = " default"; 
        }
        if (expicy_text != null)
        {
            expicy_text.text = "130se";
        }
        if (money_text != null)
        {
            money_text.text = "$0";
        }
}
    void StepOnExistWorldCavan()
    {
        if (backgroundimage != null) 
        {
            backgroundimage.color = Color.red; 
        }
        if (e_text != null)
        {
            e_text.text = "Press E to pick up this item";
        }
    }
    void ResetOnExistWorldCavan()
    {
        if (backgroundimage != null)
        {
            backgroundimage.color = Color.black;
        }
        if (e_text != null)
        {
            e_text.text = "";
        }
    }
    void  HideWorldCavan()
    {
        if (our_world_canvas != null) 
        {
            our_world_canvas.SetActive(false);
        }
    }
    void ShowWorldCavan()
    {
        if (our_world_canvas != null)
        {
            our_world_canvas.SetActive(true);
        }
    }
    #endregion

    #region Collider

    private void OnTriggerEnter(Collider other)
    {
        if (do_we_have_an_item == true) 
        {
            if (other.tag == "PlayerChild") 
            {
                StepOnExistWorldCavan();
                Debug.Log("name " + other.name);
                if (other.GetComponentInParent<ThirdPersonController>()) 
                {
                    /// 
                    if (Keyboard.current.eKey.wasPressedThisFrame) 
                    {
                        Debug.Log("player in the bench trigger and press the e key ");
                    }
                }
            }
        }
        else 
        {
            HideWorldCavan();
        }
    }

    private void OnTriggers(Collider other)
    {
        if (do_we_have_an_item == true)
        {
            if (other.tag == "PlayerChild")
            {
               StepOnExistWorldCavan();
                          
            }
        }
        else
        {
            HideWorldCavan();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (do_we_have_an_item == true)
        {
            if (other.tag == "PlayerChild")
            {
               
                //Debug.Log("name " + other.name);
                if (other.GetComponentInParent<ThirdPersonController>())
                {
                    if (!other.GetComponentInParent<ThirdPersonController>().is_player_carry)
                    {
                        if (Keyboard.current.eKey.wasPressedThisFrame)
                        {
                            Debug.Log("player in the bench trigger and press the e key ");

                            
                            if (bench_part_event != null)
                            {
                                bench_part_event(1);
                            }
                            do_we_have_an_item = false;
                            hideItemOnTop();
                        }
                    }
                }
            }
        }
        else
        {
            HideWorldCavan();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (do_we_have_an_item == true)
        {
            if (other.tag == "PlayerChild")
            {
                ResetOnExistWorldCavan();
            }
        }
        else
        {
            HideWorldCavan();
        }
    }
    #endregion


    private void Update()
    {
        
    }

    // 
    void ChoseItem(item_type choose)
    {
        if(choose == item_type.pizza_box) 
        {
            choseitem = prefabPizza;
            DisplayItemOnTop(choose);
        }
        else if (choose == item_type.hambuger)
        {
            choseitem = prefabBurger;
            DisplayItemOnTop(choose);
        }
        else if (choose == item_type.milk)
        {
            choseitem = prefabMilk;
            DisplayItemOnTop(choose);
        }
    }
   
}