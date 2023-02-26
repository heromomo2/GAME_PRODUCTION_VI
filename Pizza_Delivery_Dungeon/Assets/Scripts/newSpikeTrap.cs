using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSpikeTrap : MonoBehaviour
{
    //This script goes on the SpikeTrap prefab;

    public Animator spikeTrapAnim; //Animator for the SpikeTrap;

    public bool is_open_trap = false;

    public float time_trap = 2;

    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        if (is_open_trap == true)
        {
            StartCoroutine(OpenCloseTrap(time_trap));
        }
        else 
        {
            spikeTrapAnim.SetTrigger("open");
        }

    }


    IEnumerator OpenCloseTrap(float timer)
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(timer);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(timer);
        //Do it again;
        StartCoroutine(OpenCloseTrap(timer));

    }
}
