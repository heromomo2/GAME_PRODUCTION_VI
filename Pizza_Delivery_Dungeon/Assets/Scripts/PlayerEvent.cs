using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    private Action<int> player_state_event = null;
    public event Action<int> On_player_state_event
    {
        add
        {
            player_state_event -= value;
            player_state_event += value;
        }

        remove
        {
            player_state_event -= value;
        }
    }


    public void PlayerGotSpike()
    {
        if (player_state_event != null)
        {
            player_state_event(1);
        }
    }
}
