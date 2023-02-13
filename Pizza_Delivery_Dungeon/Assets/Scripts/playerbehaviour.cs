using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbehaviour : MonoBehaviour
{
    [SerializeField] HUD player_HUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    PlayerUseStamin(5);
        //}
        //else
        //{
        //    PlayerRegenStamina();
        //}
    }

    private void PlayerUseStamin(float  StaminaAmonut)
    {
        GameManager.game_manager.player_stamina.UseStamin(StaminaAmonut);

        player_HUD.SetStamina(GameManager.game_manager.player_stamina.Stamina);
      //  Debug.Log(GameManager.game_manager.player_stamina.health);
    }
    private void PlayerRegenStamina()
    {
        GameManager.game_manager.player_stamina.RegenStamin();
        player_HUD.SetStamina(GameManager.game_manager.player_stamina.Stamina);
    }
}
