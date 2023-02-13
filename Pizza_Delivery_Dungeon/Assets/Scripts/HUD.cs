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
   // public float max_stamina = 100f;
  //  public float current_stamina;
  //  [Range(0, 50)] [SerializeField] private float stamina_drain = 0.5f;
 //   [Range(0, 50)] [SerializeField] private float stamina_regen = 0.5f;

    [Header("Money earn")] // show how much money you earn 
    public Text text_ui_money_earned;
    public float total_money_earned;

    [Header("Delivery Fail")] // show how many fail delivery you have left
    public Text text_ui_delierly_fail;
    public float total_fail_delivery_remaining;


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

}
