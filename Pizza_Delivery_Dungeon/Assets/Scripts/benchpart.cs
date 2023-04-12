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
    public float expiry_timer;
    public float expiry_time_on_bench = 60.50f;


    /// <summary>
    /// 
    /// </summary>
    public item_type choseitem1;
    public bool do_we_have_an_item = false;
    public bool is_player_in_trigger = false;
    public string nameitem;
    public string itemcost;



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
        // set the timer
        expiry_timer = expiry_time_on_bench;
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
        hideItemOnTop();
        HideWorldCavan();
        do_we_have_an_item = false;
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
    void defaultWorldCavan()
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

    void ChangeWorldCavan(string name, float expicy_time, string money)
    {
        if (name_of_item_text != null)
        {
            name_of_item_text.text = "item: " + name;
        }
        if (expicy_text != null)
        {
            expicy_text.text = expicy_time.ToString("F0") + " sec";
        }
        if (money_text != null)
        {
            money_text.text = "$ " + money;
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
    void HideWorldCavan()
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
                is_player_in_trigger = true;

                if (bench_part_event != null)
                {
                    bench_part_event(5);
                    Debug.Log(" bench_part_event(5);");
                }

                Debug.Log("name " + other.name);

            }
        }
        else
        {
            HideWorldCavan();
        }
    }



    void OnTriggerStay(Collider other)
    {
        // testing

        if (do_we_have_an_item == true)
        {
            if (other.tag == "PlayerChild")
            {

                //Debug.Log("name " + other.name);
                if (other.GetComponentInParent<ThirdPersonController>())
                {
                    if (!other.GetComponentInParent<ThirdPersonController>().is_player_carry)
                    {
                        // the player here
                        if (bench_part_event != null)
                        {
                            bench_part_event(5);
                        }

                        if (Keyboard.current.eKey.wasPressedThisFrame)
                        {
                            Debug.Log("player in the bench trigger and press the e key ");

                            //if (choseitem != null)
                            //{
                            if (choseitem1 == item_type.hambuger)    // (choseitem == prefabBurger)
                            {
                                Debug.Log("ask from a burger ");
                                if (bench_part_event != null)
                                {
                                    bench_part_event(1);
                                }
                            }
                            else if (choseitem1 == item_type.milk) // (choseitem == prefabMilk)
                            {
                                Debug.Log("ask from a milk");
                                if (bench_part_event != null)
                                {
                                    bench_part_event(2);
                                }
                            }
                            else if (choseitem1 == item_type.pizza_box)  //(choseitem == prefabPizza)
                            {
                                Debug.Log("ask from a pizza");
                                if (bench_part_event != null)
                                {
                                    bench_part_event(3);
                                }
                            }
                            else if (choseitem1 == item_type.special)  //(choseitem == prefabPizza)
                            {
                                Debug.Log("ask from a iceCream");
                                if (bench_part_event != null)
                                {
                                    bench_part_event(7);
                                }
                            }
                            // }
                            do_we_have_an_item = false;
                            hideItemOnTop();
                            // hide it
                            if (bench_part_event != null)
                            {
                                bench_part_event(6);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            HideWorldCavan();
            if (bench_part_event != null)
            {
                bench_part_event(6);
            }
            // do_we_have_an_item = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerChild")
        {
            is_player_in_trigger = false;

            if (do_we_have_an_item == true)
            {
                ResetOnExistWorldCavan();

                if (bench_part_event != null)
                {
                    Debug.Log(" bench_part_event(6);");
                    bench_part_event(6);
                }
            }
            else
            {
                if (bench_part_event != null)
                {
                    bench_part_event(6);
                }

                HideWorldCavan();
            }
        }
    }
    #endregion


    private void Update()
    {

        if (do_we_have_an_item)
        {
            if (expiry_timer > 0)
            {
                expiry_timer -= Time.deltaTime;
            }
            else
            {
                expicy();
            }

            ChangeWorldCavan(nameitem, expiry_timer, itemcost);
        }



        //if (Keyboard.current.zKey.wasPressedThisFrame)
        //{
        //    ChoseItem(item_type.hambuger);
        //}
        //else if (Keyboard.current.xKey.wasPressedThisFrame)
        //{
        //    ChoseItem(item_type.milk);
        //}
        //else if (Keyboard.current.cKey.wasPressedThisFrame)
        //{
        //    ChoseItem(item_type.pizza_box);
        //}
        //else if (Keyboard.current.vKey.wasPressedThisFrame)
        //{
        //    ChoseItem(item_type.special);
        //}

    }
    // 
    public void ChoseItem(item_type choose)
    {
        if (choose == item_type.pizza_box)
        {
            nameitem = "Pizza";
            itemcost = "13.99";
            expiry_timer = 40f;
            hideItemOnTop();
            DisplayItemOnTop(choose);
            choseitem1 = item_type.pizza_box;
            do_we_have_an_item = true;
            ChangeWorldCavan(nameitem, expiry_timer, itemcost);
            ResetOnExistWorldCavan();
            ShowWorldCavan();
        }
        else if (choose == item_type.hambuger)
        {
            nameitem = "hamburger";
            itemcost = "10.99";
            expiry_timer = 30f;
            hideItemOnTop();
            DisplayItemOnTop(choose);
            choseitem1 = item_type.hambuger;
            do_we_have_an_item = true;
            ChangeWorldCavan(nameitem, expiry_timer, itemcost);
            ResetOnExistWorldCavan();
            ShowWorldCavan();
        }
        else if (choose == item_type.milk)
        {
            nameitem = "Milk";
            itemcost = "2.99";
            expiry_timer = 25f;
            hideItemOnTop();
            DisplayItemOnTop(choose);
            choseitem1 = item_type.milk;
            do_we_have_an_item = true;
            ChangeWorldCavan(nameitem, expiry_timer, itemcost);
            ResetOnExistWorldCavan();
            ShowWorldCavan();
        }
        else if (choose == item_type.special)
        {
            nameitem = "IceCream";
            itemcost = "5.99";
            expiry_timer = 15f;
            hideItemOnTop();
            DisplayItemOnTop(choose);
            choseitem1 = item_type.special;
            do_we_have_an_item = true;
            ChangeWorldCavan(nameitem, expiry_timer, itemcost);
            ResetOnExistWorldCavan();
            ShowWorldCavan();
        }
    }

    void expicy()
    {
        hideItemOnTop();
        HideWorldCavan();
        do_we_have_an_item = false;
        // expi
        if (bench_part_event != null)
        {
            bench_part_event(4);
        }
        if (bench_part_event != null)
        {
            bench_part_event(6);
        }
    }
}
