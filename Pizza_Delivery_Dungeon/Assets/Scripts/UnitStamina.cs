using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStamina 
{
    /// Fields
    int current_Health;
    int current_MaxHealth;


    // properties 
    public int health
    {
        get 
        {
            return current_Health;
        }
        set 
        {
            current_Health = value;
        }
    }
    public int Maxhealth
    {
        get
        {
            return current_MaxHealth;
        }
        set
        {
            current_MaxHealth = value;
        }
    }


    // Constructor
    public UnitStamina(int health, int maxhealth)
    {
        current_Health = health;
        current_MaxHealth = maxhealth;
    }

    // methods

    public void DmgUnit(int dmgAmount)
    {
        if (current_Health > 0)
        {
            current_Health -= dmgAmount;
        }
    }

    public void HealthUnit(int health)
    {
        if (current_Health < current_Health)
        {
           current_Health += health;
        }
        if (current_Health > current_MaxHealth) 
        {
            current_Health = current_MaxHealth;
        }
    }
}
