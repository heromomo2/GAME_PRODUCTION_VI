using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrderGiverAI : MonoBehaviour
{
    [SerializeField] public Transform MovePositionTransform;

    public NavMeshAgent agent;

    public item_type our_item;


    public bool is_carry_item = false;

    public bool is_move = true;

    public bool is_start_point = false;

    public bench bench;

    //public LayerMask 

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (MovePositionTransform != null && is_move == true)
        {
            if (this.gameObject.transform.position != MovePositionTransform.position)
            {
                agent.destination = MovePositionTransform.position; 
            }
        }

        if (is_start_point == true)
        {
            checkbench();
        }
    }

    private void PickRandomItem()
    {
        int random_num = Random.Range(1, 47);

        if (random_num <= 10)
        {
            our_item = item_type.milk;
            is_carry_item = true;
        }
        else if (random_num > 10 && random_num <= 20)
        {
            our_item = item_type.pizza_box;
            is_carry_item = true;
        }
        else if (random_num > 20 && random_num <= 40)
        {
            our_item = item_type.hambuger;
            is_carry_item = true;
        }
        else if (random_num > 40 && random_num <= 47)
        {
            our_item = item_type.special;
            is_carry_item = true;
        }
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "node")
        {
            if (other.GetComponent<Node>().is_firstnode)
            {
                if (is_carry_item == false)
                {
                    is_move = false;
                    StartCoroutine(WaitAndPrint(other.GetComponent<Node>().delay, other.gameObject));
                    
                    is_start_point = true;

                }

            }
            if (other.GetComponent<Node>().is_lastnode)
            {
                
                if (is_carry_item == true)
                {
                    is_move = false;
                    if (bench.GetComponent<bench>())
                    {
                        bench.GetComponent<bench>().PlaceitemOnBench(our_item);
                    }
                    StartCoroutine(WaitAndPrint(other.GetComponent<Node>().delay,  other.gameObject));                   
                    is_carry_item = false;
                    is_move = true;
                }
                
            }
            if (!other.GetComponent<Node>().is_lastnode && !other.GetComponent<Node>().is_firstnode) 
            {
                is_move = false;
                StartCoroutine(WaitAndPrint(other.GetComponent<Node>().delay, other.gameObject));
                is_move = true;
            }

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "node")
        {
            if (!other.GetComponent<Node>().is_lastnode && !other.GetComponent<Node>().is_firstnode)
            {
                other.GetComponent<Node>().SwapNode();
            }
        }
    }
    void checkbench()
    {
        if (bench.GetComponent<bench>())
        {
            if (bench.GetComponent<bench>().CheckForEmptySpotOnBench())
            {
                PickRandomItem();
                bench.GetComponent<bench>().allEmptyBench();
                is_carry_item = true;
                is_start_point = false;
                is_move = true;
            }
        }
    }


    private IEnumerator WaitAndPrint(float waitTime, GameObject other)
    {
        yield return new WaitForSeconds(waitTime);
        MovePositionTransform = other.GetComponent<Node>().next_node;
    }
}
