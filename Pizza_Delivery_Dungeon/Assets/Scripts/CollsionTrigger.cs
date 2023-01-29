using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider box_colleder;

    public GameObject destiny_location_object = null;

    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DestinyLocationTrigger"))
        {
            if (this.gameObject.CompareTag("Player"))
            {
                if (destiny_location_object != null) 
                {
                    destiny_location_object.GetComponent<DestinyLocation>().ReceiveDelivery();
                }
                
            }
        }

        
    }

}
