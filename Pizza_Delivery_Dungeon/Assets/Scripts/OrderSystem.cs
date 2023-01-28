using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    public List<GameObject> destiny_location_list;

    public List<GameObject> pizzalist;

    public List<Transform> PrevSpawned; 

    public GameObject delivery_source = null;

    public GameObject player = null;

    public float max_pizza_spawned;


    // Start is called before the first frame update
    void Start()
    {
        destiny_location_list = new List<GameObject>();
        
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("DestinyLocation"))
        {

            destiny_location_list.Add(fooObj);

        }

        if (delivery_source == null) 
        {
            delivery_source = GameObject.FindGameObjectWithTag("DeliverySource"); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
