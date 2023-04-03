using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] public Transform next_node;
    [SerializeField] public Transform prev_node;
    [SerializeField] public GameObject AI = null;
    [SerializeField] public float delay = 6;
    [SerializeField] public bool is_lastnode = false;
    [SerializeField] public bool is_firstnode = false;
    [SerializeField] public bool is_coroutine_called = false;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag =="Ai") 
        //{
        //    AI = other.gameObject;
        //    if (is_coroutine_called == false  ) 
        //    {
        //        if (is_lastnode == false)
        //        {
        //            StartCoroutine(WaitAndPrint(delay));
        //        }
        //    }
        //}
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Ai")
        //{
          
        //    if (is_coroutine_called == true)
        //    {
        //        is_coroutine_called = false;
        //    }
        //}
    }

    public void SwapNode()
    {
        Transform tempswap;
        tempswap = next_node;
        next_node = prev_node;
        prev_node = tempswap;
    }

    //private IEnumerator WaitAndPrint(float waitTime)
    //{
    //    //yield return new WaitForSeconds(waitTime);
    //    //if (AI.GetComponent<OrderGiverAI>())
    //    //{
    //    //    AI.GetComponent<OrderGiverAI>().MovePositionTransform = next_node;
    //    //}
    //    //SwapNode();
    //}
}
