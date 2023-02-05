using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DestinyLocation : MonoBehaviour
{
    // Start is called before the first frame update
    private Action<Delivery_event> Destiny_location_event = null;

    private bool is_receive_delivery;

    public List<GameObject> particle_system_list;

    private Delivery_event DE;

    public event Action<Delivery_event> On_Destiny_Location_event
    {
        add
        {
            Destiny_location_event -= value;
            Destiny_location_event += value;
        }

        remove
        {
            Destiny_location_event -= value;
        }
    }


    public GameObject destiny_location_object = null;

    void Start()
    {
       // particle_system_list = new List<GameObject>();
        ParticlesystemsOff();
    }

    private void OnDestroy()
    {

        if (Destiny_location_event != null)
        {

        }

    }
    // Update is called once per frame
    void Update()
    {

    }


    private void particlesystemsOn()
    {
        if (particle_system_list.Count > 1)
        {
            foreach (GameObject psl in particle_system_list)
            {
                psl.SetActive(true);
            }
        }
        // set on trigger
        if (destiny_location_object != null) 
        {
            destiny_location_object.SetActive(true);
        }
    }

    private void ParticlesystemsOff()
    {
       // Debug.Log("particlesystemsOff");
        if (particle_system_list.Count > 1)
        {
           // Debug.Log("particlesystemsOff");
            foreach (GameObject psl in particle_system_list)
            {
               // Debug.Log("particlesystemsOff");
                psl.SetActive(false);
            }
        }
        // set off trigger
        if (destiny_location_object != null)
        {
            destiny_location_object.SetActive(false);
        }
    }

    public void ReceiveDelivery()
    {
        if (Destiny_location_event != null)
        {
            DE = Delivery_event.Delilvery_End;
            Destiny_location_event(DE);
        }
        ParticlesystemsOff();
    }

    public void SetParticleOn()
    {
        if (Destiny_location_event != null)
        {
            DE = Delivery_event.Delilvery_Start;
            Destiny_location_event(DE);
        }
        particlesystemsOn();
    }

    public void FailDelivery()
    {
        ParticlesystemsOff();
    }


}
public enum Delivery_event
{
    Delilvery_End,
    Delilvery_Start,
}