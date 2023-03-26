using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class benchpart : MonoBehaviour
{
    [Header("item")]
    public GameObject prefabMilk;
    public GameObject prefabBurger;
    public GameObject prefabPizza;


    [Header("display item")]
    public Transform point_of_display;
    public List<GameObject> display_item_list;
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


    private void Start()
    {
        init();
    }
    void init()
    {
        /// place them int the right positon
        /// set to invisble
        if (display_item_list.Count > 0)
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
        if (display_item_list.Count > 0)
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
    #region UI(world space)
    void ChangeWorldCavan()
    {
      name_of_item_text.text = " default";
      expicy_text.text = "130se";
     money_text.text  = "$0";
}
    void StepOnExistWorldCavan()
    {
        backgroundimage.color = Color.red;
        e_text.text = "Press E to pick up this item";
    }
    void ResetOnExistWorldCavan()
    {
        backgroundimage.color =  Color.black;
        e_text.text = "";
    }
    void  HideWorldCavan()
    {
        our_world_canvas.SetActive(false);
    }
    void ShowWorldCavan()
    {
        our_world_canvas.SetActive(true);
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
}
