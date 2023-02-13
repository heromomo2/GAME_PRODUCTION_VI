using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStamina
{
    /// Fields
    float current_stamina;
    float current_max_stamina;
    float stamina_regen_speed;
    bool pause_stamina_regen = false;
    float inital_chunk;
    bool is_inital_chunk_used = false;
    float delay_time_stamina_regen;
    float delay_time_stamina_regen_timer;

    // properties 
    public float Stamina
    {
        get
        {
            return current_stamina;
        }
        set
        {
            current_stamina = value;
        }
    }
    public float MaxStamina
    {
        get
        {
            return current_max_stamina;
        }
        set
        {
            current_max_stamina = value;
        }
    }


    public float StaminRengSpeed
    {
        get
        {
            return stamina_regen_speed;
        }
        set
        {
            current_stamina = value;
        }
    }
    public bool PauseStaminaRegen
    {
        get
        {
            return pause_stamina_regen;
        }
        set
        {
            pause_stamina_regen = value;
        }
    }

    public float InitalChunk
    {
        get
        {
            return inital_chunk;
        }
        set
        {
            inital_chunk = value;
        }
    }
    public bool IsInitalChunkUsed
    {
        get
        {
            return is_inital_chunk_used;
        }
        set
        {
            is_inital_chunk_used = value;
        }
    }



    // Constructor
    public UnitStamina(float stamina, float max_stamina, float staminaregen_speed, bool pasuestamina_regen, float initalchunk, bool inital_chunk_used,float delaytime_stamina_regen)
    {
        current_stamina = stamina;
        current_max_stamina = max_stamina;
        stamina_regen_speed = staminaregen_speed;
        pause_stamina_regen = pasuestamina_regen;
        inital_chunk = initalchunk;
        is_inital_chunk_used = inital_chunk_used;
        delay_time_stamina_regen = delaytime_stamina_regen;
        // set the timer for first time
        delay_time_stamina_regen_timer = delay_time_stamina_regen;
    }

    // methods

    public void UseStamin(float StaminaAmount)
    {
        if (current_stamina > 0)
        {
            if (!is_inital_chunk_used)
            {
                current_stamina -= inital_chunk;
                is_inital_chunk_used = true;
            }
            else
            {
                current_stamina -= StaminaAmount * Time.deltaTime;
            }
            delay_time_stamina_regen_timer = delay_time_stamina_regen;
        }
    }

    public void RegenStamin()
    {
        if (delay_time_stamina_regen_timer < 0f)
        {
            if (current_stamina < current_max_stamina && !pause_stamina_regen)
            {
                current_stamina += stamina_regen_speed * Time.deltaTime;
                is_inital_chunk_used = false;
            }
        }
        else 
        {
            delay_time_stamina_regen_timer -= Time.deltaTime;
            is_inital_chunk_used = false;
        }
    }
}
