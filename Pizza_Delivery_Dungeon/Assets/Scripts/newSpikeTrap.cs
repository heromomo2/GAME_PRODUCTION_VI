using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpikeTrap : MonoBehaviour
{
    //This script goes on the SpikeTrap prefab;

    public Animator spike_trap_anim; //Animator for the SpikeTrap;

    public bool is_open_trap = false;

    public float time_trap = 2;

    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        spike_trap_anim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        if (is_open_trap == true)
        {
            StartCoroutine(OpenCloseTrap(time_trap));
        }
        else 
        {
            spike_trap_anim.SetTrigger("open");
        }

    }


    IEnumerator OpenCloseTrap(float timer)
    {
        //play open animation;
        spike_trap_anim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(timer);
        //play close animation;
        spike_trap_anim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(timer);
        //Do it again;
        StartCoroutine(OpenCloseTrap(timer));

    }
}
