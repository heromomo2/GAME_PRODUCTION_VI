using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager game_manager { get; private set; }

    public UnitStamina player_stamina = new UnitStamina(100f, 100f, 30f, false, 25f, false, 10.0f );

    void Awake()
    {
        if (game_manager != null && game_manager != this) 
        {
            Destroy(this);
        }
        else 
        {
            game_manager = this;
        }
    }

    
}
