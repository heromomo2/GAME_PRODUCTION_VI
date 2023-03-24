using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class benchpart : MonoBehaviour
{
    [Header("display item")]
    public Transform point_of_display;
    public List<GameObject> display_item_list;
    public GameObject pick_item;
    public bool do_we_have_an_item = false;


    [Header("worldCavan")]
    public Canvas our_world_canvas;

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
        if(display_item_list.Count> 0)
        {
            foreach(GameObject d in display_item_list) 
            {
                d.transform.position = point_of_display.position;
                d.SetActive(false);
            }
        }

        if(our_world_canvas != null) 
        {
            our_world_canvas.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);
        }
        Display(item_type.hambuger);
   }

   void Display(item_type item_display) 
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

}
