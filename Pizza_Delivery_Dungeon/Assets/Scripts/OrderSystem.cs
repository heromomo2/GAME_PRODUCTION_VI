using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
public class OrderSystem : MonoBehaviour
{
    [Header("Deliverly")]
    public List<GameObject> destiny_location_list;

    public GameObject delivery_source_pizza = null;

    public GameObject delivery_source_milk = null;

    public GameObject player = null;

    public bool is_destiny_selected = false;

    public GameObject Selected_destiny = null;

    [Header("Pizza")]
    public GameObject pizza_prefab;
    public List<GameObject> pizza_list;
    public int max_pizza_spawned = 10;
    public int max_spawn_amount = 0;
    public float random_pizza_spawn_timer = 0f;

    [Header("Milk")]
    public GameObject milk_prefab;
    public List<GameObject> milk_list;
    public int max_milk_spawned = 5;
    public float random_milk_spawn_timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        destiny_location_list = new List<GameObject>();


        foreach (GameObject dl in GameObject.FindGameObjectsWithTag("DestinyLocation"))
        {
            destiny_location_list.Add(dl);


        }

        // destiny_location_list.Add(GameObject.FindGameObjectsWithTag("DeliveryLocation"));

        foreach (GameObject dl in destiny_location_list)
        {

            if (dl.GetComponent<DestinyLocation>() != null)
            {
                dl.GetComponent<DestinyLocation>().On_Destiny_Location_event += DestinyLocationEventListener;
            }
        }

        if (delivery_source_pizza == null)
        {
            delivery_source_pizza = GameObject.FindGameObjectWithTag("DeliverySource");
        }

        random_pizza_spawn_timer = 5.0f;//Random.Range(10, 40.0f);

        random_milk_spawn_timer = 3.0f;

        // pizza gen
        StartCoroutine(StartGenerateDeliverlyBoxes(random_pizza_spawn_timer, max_pizza_spawned,pizza_list,pizza_prefab,delivery_source_pizza));
        // milk gen
        StartCoroutine(StartGenerateDeliverlyBoxes(random_milk_spawn_timer, max_milk_spawned, milk_list, milk_prefab, delivery_source_milk));

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
                    Selected_destiny = destiny_location_list[Random.Range(0, destiny_location_list.Count)];
                    Selected_destiny.GetComponent<DestinyLocation>().SetParticleOn();
                }
            }
        }

        // Debug.Log("Pizzacount " + pizza_list.Count);
    }



    //IEnumerator StartGenerateMilkBoxes(float timer)
    //{
    //    yield return new WaitForSeconds(timer);

    //    if (milk_list != null)
    //    {
    //        if (max_milk_spawned > milk_list.Count)
    //        {
    //            if (milk_prefab != null && delivery_source_milk != null)
    //            {
    //                GameObject new_milk;
    //                new_milk = Instantiate(pizza_prefab, delivery_source.transform.position, Quaternion.identity);

    //                if (new_milk.GetComponent<PickUpItem>() != null)
    //                {
    //                    new_milk.GetComponent<PickUpItem>().On_pick_up_item_event += PizzaEventListener;
    //                }
    //                milk_list.Add(new_milk);

    //                random_timer = Random.Range(5.0f, 10.0f);

    //                StartCoroutine(StartGenerateMilkBoxes(random_timer));

    //            }

    //        }
    //    }

    //}

    // this work
    //IEnumerator StartGenerateDeliverlyBoxes(float timer)
    //{
    //    yield return new WaitForSeconds(timer);

    //    if (pizza_list != null)
    //    {
    //        if (max_pizza_spawned > pizza_list.Count)
    //        {
    //            if (pizza_prefab != null && delivery_source_pizza != null)
    //            {
    //                max_spawn_amount = max_pizza_spawned - pizza_list.Count;
    //                GameObject new_pizza;
    //                int random_amount = Random.Range(1, max_spawn_amount);
    //                for (int i = random_amount;  i > 0; i-- )
    //                {
    //                    new_pizza = Instantiate(pizza_prefab, delivery_source_pizza.transform.position, Quaternion.identity);
    //                    if (new_pizza.GetComponent<PickUpItem>() != null)
    //                    {
    //                        new_pizza.GetComponent<PickUpItem>().On_pick_up_item_event += PizzaEventListener;
    //                    }
    //                    pizza_list.Add(new_pizza);
    //                }

    //                random_timer = Random.Range(0.5f, 4.0f);

    //                StartCoroutine(StartGenerateDeliverlyBoxes(random_timer));

    //            }

    //        }
    //        else 
    //        {
    //            CleanUpListOfMissingGameObject(pizza_list);

    //            random_timer = Random.Range(5.0f, 10.0f);

    //            StartCoroutine(StartGenerateDeliverlyBoxes(random_timer));
    //        }
    //    }

    //}

    IEnumerator StartGenerateDeliverlyBoxes(float timer, int max_item_spawned, List<GameObject> item_list, GameObject our_item_prefab, GameObject delivery_source)
    {
        yield return new WaitForSeconds(timer);

        if (item_list != null)
        {
            if (max_item_spawned > item_list.Count)
            {
                if (our_item_prefab != null && delivery_source != null)
                {
                    max_spawn_amount = max_item_spawned - item_list.Count;
                    GameObject new_item;

                    int random_amount = Random.Range(1, max_spawn_amount);

                    for (int i = random_amount; i > 0; i--)
                    {
                        new_item = Instantiate(our_item_prefab, delivery_source.transform.position, Quaternion.identity);

                        if (new_item.GetComponent<PickUpItem>() != null)
                        {
                            new_item.GetComponent<PickUpItem>().On_pick_up_item_event += PizzaEventListener;
                        }


                        item_list.Add(new_item);

                    }

                    timer = Random.Range(0.5f, 4.0f);

                    StartCoroutine(StartGenerateDeliverlyBoxes(timer, max_item_spawned, item_list, our_item_prefab, delivery_source));

                }

            }
            else
            {
                CleanUpListOfMissingGameObject(item_list);

                timer = Random.Range(5.0f, 10.0f);

                StartCoroutine(StartGenerateDeliverlyBoxes(timer, max_item_spawned, item_list, our_item_prefab, delivery_source));
            }
        }

    }





    public void DestinyLocationEventListener(Delivery_event de)
    {
        if (de == Delivery_event.Delilvery_End)
        {
            if (player.GetComponent<ThirdPersonController>() != null)
            {
                //            Debug.Log("OrderSystem got the message from DestinyLocation");

                Boxhandle holdpoint = player.GetComponentInChildren(typeof(Boxhandle), true) as Boxhandle;
                if (holdpoint != null)
                {
                    holdpoint.RemovePizzaFromPlayer();
                    is_destiny_selected = false;
                }
            }
        }

    }

    public void PizzaEventListener(int i)
    {  // player is carry a expiry pizza
        if (i == 1)
        {
            if (player.GetComponent<ThirdPersonController>() != null)
            {
                Debug.Log("OrderSystem got the message from expiry pizza");

                Boxhandle holdpoint = player.GetComponentInChildren(typeof(Boxhandle), true) as Boxhandle;
                if (holdpoint != null)
                {
                    foreach (GameObject dl in destiny_location_list)
                    {
                        if (dl.GetComponent<DestinyLocation>() != null)
                        {
                            dl.GetComponent<DestinyLocation>().FailDelivery();
                        }
                    }
                    holdpoint.RemoveExpiryPizzaPlayer();
                    is_destiny_selected = false;
                }
            }
        }
    }



    void CleanUpListOfMissingGameObject(List<GameObject> our_list)
    {
        for (var i = our_list.Count - 1; i > -1; i--)
        {
            if (our_list[i] == null)
            {
                our_list.RemoveAt(i);
            }
        }
    }
}


