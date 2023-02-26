using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider box_colleder;

    public GameObject destiny_location = null;

    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PlayerChild"))
        {

            if (destiny_location != null)
            {
                destiny_location.GetComponent<DestinyLocation>().ReceiveDelivery();
                Debug.Log("Playerchild is the the trigger1");
            }

        }

    }

}
