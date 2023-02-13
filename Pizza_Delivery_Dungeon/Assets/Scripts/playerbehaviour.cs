using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.game_manager.player_stamina.health);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.game_manager.player_stamina.health);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.game_manager.player_stamina.DmgUnit(dmg);
        Debug.Log(GameManager.game_manager.player_stamina.health);
    }
    private void PlayerHeal(int healthing)
    {
        GameManager.game_manager.player_stamina.HealthUnit(healthing)
    }
}
