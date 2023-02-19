using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Deliverly timer")] // how much time before the player deliver all the thing
    public Text text_ui_delierly_timer;
    public float total_deliverly_time;
    public float total_deliver_remaining;

    [Header("Stamina bar")] // how  much stamin for sprint
    public Slider stamina_bar;
  

    [Header("Money earn")] // show how much money you earn 
    public Text text_ui_money_earned;

    [Header("lives")] // show many lives you have
    public Text text_ui_lives;
 

    [Header("Delivered")] // show how many delivery you did
    public Text text_ui_deliered;

    [Header("GameTimer")] // show how much time is left
    public Text text_ui_game_timer;



    // Start is called before the first frame update
    void Start()
    {

    }

    #region StaminaCode
    public void SetMaxStamina(float max_stamina)
    {
        stamina_bar.maxValue = max_stamina;
        stamina_bar.value = max_stamina;
    }

    public void SetStamina(float stamina)
    {
        stamina_bar.value = stamina;  
    }
    #endregion

    #region PointCode
    public void DisplayMoneyEarn(float money_earned)
    {
        text_ui_money_earned.text = money_earned.ToString();
    }

    #endregion

    #region Game Timer
    public void DisplayGameTimer(float game_timer)
    {
        text_ui_delierly_timer.text = game_timer.ToString();
    }
    #endregion

    #region delivered
    public void DisplayDelivered(int successs)
    {
        text_ui_deliered.text = successs.ToString();
    }
    #endregion

    #region lives
    public void Displaylives(int lives)
    {
        text_ui_lives.text = lives.ToString();
    }
    #endregion
}
