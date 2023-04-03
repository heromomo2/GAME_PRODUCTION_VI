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

    public GameObject delivery_source_hambuger = null;

    public GameObject player = null;

    public bool is_destiny_selected = false;

    public GameObject Selected_destiny = null;

    [Header("Pizza")]
    public GameObject pizza_prefab;
    public List<GameObject> pizza_list;
    public int max_pizza_spawned = 10;
    private float pizza_spawn_timer = 0f;
    public float max_pizza_spawn_time = 10.0f;
    public float min_pizza_spawn_time = 5.0f;

    [Header("Milk")]
    public GameObject milk_prefab;
    public List<GameObject> milk_list;
    public int max_milk_spawned = 0;
    private float milk_spawn_timer = 0f;
    public float max_milk_spawn_time = 55.0f;
    public float min_milk_spawn_time = 13.0f;

    [Header("Hambuger")]
    public GameObject hambuger_prefab;
    public List<GameObject> hambuger_list;
    public int max_hambuger_spawned = 2;
    private float hambuger_spawn_timer = 0f;
    public float max_hambuger_spawn_time = 30.0f;
    public float min_hambuger_spawn_time = 10.0f;

    //  this is being use be spawn for all items
    public int max_spawn_amount = 0;

    [Header("Destination")]
    public float distance;
    public float time_between_objects;
    public float speed;
    public float inital_deliver_time; // use for bonus point
    public float end_deliver_time;// use for bonus point
    [Header("HUD")]

    [SerializeField] private HUD player_hud;

    [Header("theBench")]

    [SerializeField] GameObject bench;


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

        pizza_spawn_timer = 5.0f;//Random.Range(10, 40.0f);

        milk_spawn_timer = 3.0f;

        // pizza gen
     //   StartCoroutine(StartGenerateDeliverlyBoxes(pizza_spawn_timer, max_pizza_spawn_time, min_pizza_spawn_time, max_pizza_spawned, pizza_list, pizza_prefab, delivery_source_pizza));
        // milk gen
     //   StartCoroutine(StartGenerateDeliverlyBoxes(milk_spawn_timer, max_milk_spawn_time, min_milk_spawn_time, max_milk_spawned, milk_list, milk_prefab, delivery_source_milk));
        // hambuger gen
        StartCoroutine(StartGenerateDeliverlyBoxes(hambuger_spawn_timer, max_hambuger_spawn_time, min_hambuger_spawn_time, max_hambuger_spawned, hambuger_list, hambuger_prefab, delivery_source_hambuger));

        /// when the player get hit with spike
        ///  we add listener to hear for  player state
        if (player.GetComponent<PlayerEvent>() != null)
        {
            player.GetComponent<PlayerEvent>().On_player_state_event += PlayerStateEventListener;
        }

        
        if (bench != null && bench.GetComponent<bench>()!= null)  
        {
            bench.GetComponent<bench>().On_bench_event += BenchEventListener;
        }

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
                    // Selected_destiny = destiny_location_list[Random.Range(0, destiny_location_list.Count)];
                    SetDestination();
                    if (Selected_destiny == null)
                    {
                        Debug.LogError("Selected_Destiny has not beem asignn");
                    }
                    else
                    {
                        Selected_destiny.GetComponent<DestinyLocation>().SetParticleOn();
                    }
                }
            }
        }

        // Debug.Log("Pizzacount " + pizza_list.Count);
        player_hud.SetitemTimer(GameManager.game_manager.carry_item_timer);
    }





    IEnumerator StartGenerateDeliverlyBoxes(float timer, float max_time, float min_time, int max_item_spawned, List<GameObject> item_list, GameObject our_item_prefab, GameObject delivery_source)
    {
        yield return new WaitForSeconds(timer);

        if (item_list != null)
        {
            if (max_item_spawned > item_list.Count)
            {
                if (our_item_prefab != null && delivery_source != null)
                {
                    /**
                     * checking how many space we have in itemlist and making should  we don't pass the cap how many are allow on screen
                     **/
                    max_spawn_amount = max_item_spawned - item_list.Count;

                    GameObject new_item;

                    int random_amount = Random.Range(1, max_spawn_amount);// random amount 

                    for (int i = random_amount; i > 0; i--)
                    {
                        new_item = Instantiate(our_item_prefab, delivery_source.transform.position, Quaternion.identity);

                        if (new_item.GetComponent<PickUpItem>() != null)
                        {
                            new_item.GetComponent<PickUpItem>().On_pick_up_item_event += ItemEventListener;
                        }


                        item_list.Add(new_item);

                    }

                    if (min_time != null && min_time != null)
                    {
                        timer = Random.Range(min_time, max_time);

                        StartCoroutine(StartGenerateDeliverlyBoxes(timer, max_time, min_time, max_item_spawned, item_list, our_item_prefab, delivery_source));
                    }

                }

            }
            else
            {
                // we spawning while  clean the list of item of missing 
                CleanUpListOfMissingGameObject(item_list);

                timer = Random.Range(min_time, max_time);


                StartCoroutine(StartGenerateDeliverlyBoxes(timer, max_time, min_time, max_item_spawned, item_list, our_item_prefab, delivery_source));
            }
        }

    }


    void BenchAskToGenerateDeliverly(List<GameObject> item_list, GameObject our_item_prefab, GameObject player) 
    {
        Debug.Log("BenchAskToGenerateDeliverly was called");
        if (item_list != null) 
        {
            if (our_item_prefab != null && player != null) 
            {
                CleanUpListOfMissingGameObject(item_list);
                if (!player.GetComponent<ThirdPersonController>().is_player_carry)
                {
                    GameObject new_item;
                    new_item = Instantiate(our_item_prefab, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
                    new_item.GetComponent<PickUpItem>().On_pick_up_item_event += ItemEventListener;
                    item_list.Add(new_item);
                }
            }


        }

    }
    void BenchAskToRemoveALiveFromPlayer()
    {
        Debug.Log("BenchAskToRemoveALiveFromPlayer was called");
        GameManager.game_manager.time_and_lives.RemoveALife();
        player_hud.Displaylives(GameManager.game_manager.time_and_lives.Playerlives);
    }



    /// <summary>
    ///  complete a delivery
    /// </summary>
    /// <param name="de"></param>

    public void DestinyLocationEventListener(Delivery_event de)
    {
        if (de == Delivery_event.Delilvery_End)
        {
            if (player.GetComponent<ThirdPersonController>() != null)
            {
                //Debug.Log("OrderSystem got the message from DestinyLocation");


                Boxhandle holdpoint = player.GetComponentInChildren(typeof(Boxhandle), true) as Boxhandle;
                if (holdpoint != null)
                {
                    // figure out the item that was deliver for point
                    GameManager.game_manager.player_score.AddToScore(holdpoint.carried_item.GetComponent<PickUpItem>().our_item);


                    end_deliver_time = holdpoint.carried_item.GetComponent<PickUpItem>().expiry_timer_while_carry_item;

                    // Debug.Log("1end_deliver_time-> " + end_deliver_time);

                    GameManager.game_manager.player_score.CheckForBonus(end_deliver_time, inital_deliver_time);
                    Debug.Log(" end_deliver_time-> " + end_deliver_time + " inital_deliver_time-> " + inital_deliver_time);

                    GameManager.game_manager.built_In_difficulty.CheckForDifficuly();// increase Difficuly



                    player_hud.DisplayMoneyEarn(GameManager.game_manager.player_score.Score); // update the score on hud;
                    player_hud.DisplayDelivered(GameManager.game_manager.built_In_difficulty.DifficultyCounter);// 
                    player_hud.DisplayDeliveredName(GameManager.game_manager.built_In_difficulty.DifficultyLevel);//

                    holdpoint.RemoveCarriedItemFromPlayer(false);//remove the item from the player
                    player_hud.HideItemTimer();// hide the timer
                    is_destiny_selected = false;
                }

            }
        }

    }
    /// <summary>
    ///  fail a delivery while carrying item
    /// </summary>
    /// <param name="i"></param>
    public void ItemEventListener(int i)
    {  // player is carry a expiry pizza
        if (i == 1)
        {
            if (player.GetComponent<ThirdPersonController>() != null)
            {
                Debug.Log("OrderSystem got the message from expiry item");

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
                    GameManager.game_manager.time_and_lives.RemoveALife();
                    player_hud.Displaylives(GameManager.game_manager.time_and_lives.Playerlives);
                    holdpoint.ResetPlayerAfterFailDelivery();
                    player_hud.HideItemTimer();// hide the timer
                    is_destiny_selected = false;
                }
            }
        }
    }


    public void PlayerStateEventListener(int i)
    {
        if (i == 1)
        {
            if (player.GetComponent<ThirdPersonController>() != null)
            {
                //Debug.Log("OrderSystem got the message from expiry item");

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
                    GameManager.game_manager.time_and_lives.RemoveALife();
                    player_hud.Displaylives(GameManager.game_manager.time_and_lives.Playerlives);
                    holdpoint.RemoveCarriedItemFromPlayer(true);
                    player_hud.HideItemTimer();// hide the timer
                    is_destiny_selected = false;
                }
            }
        }
    }



    public void BenchEventListener(int i)
    {
        Debug.Log("BenchEventListener was called");
        if (i == 1)
        {
            Debug.Log("hamburger spawn on player");
            BenchAskToGenerateDeliverly(hambuger_list, hambuger_prefab, player);
        }
        if (i == 2) 
        {
            Debug.Log("milk spawn on player");
            BenchAskToGenerateDeliverly( milk_list, milk_prefab, player);
        }
        if (i == 3)
        {
            Debug.Log("pizza spawn on player");
            BenchAskToGenerateDeliverly(pizza_list, pizza_prefab, player);
        }
        if (i == 4)
        {
            Debug.Log("player has let item expicy on bench");
            BenchAskToRemoveALiveFromPlayer();
        }
    }

    /// <summary>
    /// clean up the list of item so the list isnt fill with misssing gameobject
    /// </summary>
    /// <param name="our_list"></param>
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



    void SetDestination()
    {
        if (player.GetComponent<ThirdPersonController>() != null)
        {
            // get player speed
            speed = player.GetComponent<ThirdPersonController>().MoveSpeed;

            Boxhandle holdpoint = player.GetComponentInChildren(typeof(Boxhandle), true) as Boxhandle;
            if (holdpoint != null)
            {
                GameObject temp_destination;
                float temp_distance = 0.1f;
                bool is_first_loop = true;

                // find out what the player is carrying before pick a destinattion
                if (holdpoint.carried_item.GetComponent<PickUpItem>().our_item == item_type.pizza_box)
                {
                    // radom
                    Selected_destiny = destiny_location_list[Random.Range(0, destiny_location_list.Count)];

                    distance = Vector3.Distance(player.transform.position, Selected_destiny.GetComponent<DestinyLocation>().destiny_location_object.transform.position);

                    time_between_objects = distance / GameManager.game_manager.built_In_difficulty.SpeedDifficuly;//  change to speed_Increase_difficuly_for_delivery instead speed


                    // need for calculateing bonus points 
                    inital_deliver_time = time_between_objects;

                    holdpoint.carried_item.GetComponent<PickUpItem>().after_pick_up_expiry_time = time_between_objects;

                    /// show the timer
                   /// GameManager.game_manager.itemTimer2 = holdpoint.carried_item.GetComponent<PickUpItem>().after_pick_up_expiry_time;
                    player_hud.ShowItemTimer();
                    player_hud.SetItemTimerMexMin(0, time_between_objects);
                    //player_hud.SetitemTimer(GameManager.game_manager.itemTimer2);

                } // check what item is be pick up
                else if (holdpoint.carried_item.GetComponent<PickUpItem>().our_item == item_type.milk)
                {
                    // find the closest destination
                    foreach (GameObject dl in destiny_location_list)
                    {
                        distance = Vector3.Distance(player.transform.position, dl.GetComponent<DestinyLocation>().destiny_location_object.transform.position);

                        if (is_first_loop == true)
                        {
                            is_first_loop = false;
                            temp_distance = distance;
                            Selected_destiny = dl;
                        }
                        else if (temp_distance > distance)
                        {
                            temp_distance = distance;
                            Selected_destiny = dl;
                        }
                    }
                    // get the time for  travel time
                    time_between_objects = distance / GameManager.game_manager.built_In_difficulty.SpeedDifficuly;

                    // need for calculateing bonus points 
                    inital_deliver_time = time_between_objects;
                    // add the travel time to the milk 
                    holdpoint.carried_item.GetComponent<PickUpItem>().after_pick_up_expiry_time = time_between_objects; //(time_between_objects - 10.0f);

                    /// show the timer
                    /// GameManager.game_manager.itemTimer2 = holdpoint.carried_item.GetComponent<PickUpItem>().after_pick_up_expiry_time;
                    player_hud.ShowItemTimer();
                    player_hud.SetItemTimerMexMin(0, time_between_objects);
                    //player_hud.SetitemTimer(GameManager.game_manager.itemTimer2);
                }
                else if (holdpoint.carried_item.GetComponent<PickUpItem>().our_item == item_type.hambuger)
                {
                    GameObject temp_distination3 = null;

                    // get the far distination
                    foreach (GameObject dl in destiny_location_list)
                    {
                        distance = Vector3.Distance(player.transform.position, dl.GetComponent<DestinyLocation>().destiny_location_object.transform.position);

                        if (is_first_loop == true)
                        {
                            is_first_loop = false;
                            temp_distance = distance;
                            temp_distination3 = dl;
                        }
                        else if (temp_distance < distance)
                        {
                            temp_distance = distance;
                            temp_distination3 = dl;
                        }
                    }

                    Selected_destiny = temp_distination3;

                    if (temp_distination3 != null && Selected_destiny != null)
                    {
                        // we do don't want it to this destination
                        while (Selected_destiny == temp_distination3)
                        {
                            Selected_destiny = destiny_location_list[Random.Range(0, destiny_location_list.Count)];
                        }

                        distance = Vector3.Distance(player.transform.position, Selected_destiny.GetComponent<DestinyLocation>().destiny_location_object.transform.position);

                        // get the time for  travel time
                        time_between_objects = distance / GameManager.game_manager.built_In_difficulty.SpeedDifficuly;

                        // need for calculateing bonus points 
                        inital_deliver_time = time_between_objects;

                        // add the travel time to the hambuger
                        holdpoint.carried_item.GetComponent<PickUpItem>().after_pick_up_expiry_time = time_between_objects; //(time_between_objects - 10.0f);


                        /// show the timer
                        /// GameManager.game_manager.itemTimer2 = holdpoint.carried_item.GetComponent<PickUpItem>().after_pick_up_expiry_time;
                        player_hud.ShowItemTimer();
                        player_hud.SetItemTimerMexMin(0, time_between_objects);
                        //player_hud.SetitemTimer(GameManager.game_manager.itemTimer2);
                    }




                }
            }

        }
    }

}


