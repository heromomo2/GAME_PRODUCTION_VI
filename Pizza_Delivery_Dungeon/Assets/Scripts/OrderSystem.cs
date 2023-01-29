using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
public class OrderSystem : MonoBehaviour
{
    public List<GameObject> destiny_location_list;

    public List<GameObject> pizza_list;

    public  GameObject pizza_prefab;

    public List<Transform> prev_spawned; 

    public GameObject delivery_source = null;

    public GameObject player = null;

    public float max_pizza_spawned;

    public float random_timer = 0f;

    public bool is_destiny_selected = false;
    public GameObject Selected_destiny = null;

    // Start is called before the first frame update
    void Start()
    {
        //destiny_location_list = new List<GameObject>();
        
        //foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("DestinyLocation"))
        //{

        //    destiny_location_list.Add(fooObj);

        //}

        if (delivery_source == null) 
        {
            delivery_source = GameObject.FindGameObjectWithTag("DeliverySource"); 
        }

        random_timer = 5.0f;//Random.Range(10, 40.0f);

        StartCoroutine(StartGenerateDeliverlyBoxes(random_timer));

    }

    // Update is called once per frame
    void Update()
    {

        ///pick a destiny for the player
        if (player != null) 
        {
            if (player.GetComponent<ThirdPersonController>().is_player_carry == true) 
            {
                if (is_destiny_selected == false)
                {
                    is_destiny_selected = true;
                    Selected_destiny =  destiny_location_list[Random.Range(0, destiny_location_list.Count)];
                    Selected_destiny.GetComponent<DestinyLocation>().SetParticleOn();
                } 
            }
        }
    }

    IEnumerator StartGenerateDeliverlyBoxes(float timer)
    {
        yield return new WaitForSeconds(timer);

        if (pizza_list != null) 
        {
            if (max_pizza_spawned > pizza_list.Count)
            {
                if (pizza_prefab != null && delivery_source != null)
                {
                    GameObject new_pizza;
                    new_pizza = Instantiate(pizza_prefab, delivery_source.transform.position, Quaternion.identity);
                    pizza_list.Add(new_pizza);

                    random_timer = Random.Range(5.0f, 10.0f);

                    StartCoroutine(StartGenerateDeliverlyBoxes(random_timer));

                }

            } 
        }

    }


}
