using StarterAssets;
using UnityEngine;

public class Boxhandle : MonoBehaviour
{
    public GameObject carried_item;

    public Transform _holdpoint;


    public int max_item_holded = 1;
    public int item_holded_counter = 0;


    public ThirdPersonController player_3rd_person_controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AttendCarriedItemToPlayer(GameObject item)
    {
        if (player_3rd_person_controller.is_player_pick_up == true)
        {
            if (item.tag == "Pizzabox" || item.tag == "Item")
            {
                if (max_item_holded > item_holded_counter)
                {
                    item_holded_counter = item_holded_counter + 1;

                    // GameObject child_object = _holdpoint.gameObject;
                    item.transform.position = new Vector3 (item.transform.position.x, _holdpoint.transform.position.y + 0.2f, item.transform.position.z);
                    item.transform.parent = _holdpoint.transform;
                    player_3rd_person_controller.is_player_carry = true;
                    carried_item = item;
                    carried_item.GetComponent<PickUpItem>().is_pick_up = true;
                    //carried_item.GetComponent<PickUpItem>().ResetOurRotation();
                    carried_item.tag = "Untagged";
                    carried_item.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    public void RemoveCarriedItemFromPlayer()
    {
        if (carried_item != null)
        {
            Destroy(carried_item);
            carried_item = null;
            player_3rd_person_controller.is_player_carry = false;
            player_3rd_person_controller.is_player_overlap_pizza = false;
            item_holded_counter = 0;
        }
    }

    public void RemoveExpiryPizzaPlayer()
    {
        player_3rd_person_controller.is_player_carry = false;
        player_3rd_person_controller.is_player_overlap_pizza = false;
        item_holded_counter = 0;
    }

}
