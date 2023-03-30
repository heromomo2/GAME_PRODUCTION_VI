using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Deliverly timer")] // how much time before the player deliver all the thing
    public Text text_ui_delierly_timer;
   

    [Header("Stamina bar")] // how  much stamin for sprint
    public Slider stamina_bar;
  

    [Header("Money earn")] // show how much money you earn 
    public Text text_ui_money_earned;

    [Header("lives")] // show many lives you have
    public Text text_ui_lives;


    [Header("Delivered")] // show how many delivery you did
    public Text text_ui_deliered_name;
    public Text text_ui_deliered;
    

    [Header("GameTimer")] // show how much time is left
    public Text text_ui_game_timer;

    [Header("BenchUI")] // show item info before pick up
    public GameObject bench_ui;
    public Text bench_text_ui_deliered_name;
    public Text bench_text_ui_deliered_money;
    public Text bench_text_ui_deliered_epire;

    [Header("timerUI")] // show how many time you have to deliver
    public Slider time_stamina_bar;


    // Start is called before the first frame update
    void Start()
    {
        HideBenchInfo();
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
        text_ui_money_earned.text = "$ " + money_earned.ToString("F");
    }

    #endregion

    #region Game Timer
    public void DisplayGameTimer()
    {
        text_ui_delierly_timer.text = string.Format("{0:00}:{1:00}", GameManager.game_manager.time_and_lives.GetGameTimerMinute, GameManager.game_manager.time_and_lives.GetGameTimerSeconds);
    }
    #endregion

    #region Delivered
    public void DisplayDelivered(int successs)
    {
        text_ui_deliered.text = successs.ToString();
    }
    public void DisplayDeliveredName(int difffculyLevel)
    {
       

        if (difffculyLevel == 1)
        {
            text_ui_deliered_name.color = Color.green; 
            text_ui_deliered.color = Color.green;
           // Debug.Log("DeliveredName and Deliverednumer should be green");
        }
        if (difffculyLevel == 2)
        {
            Color orange_color = new Color(1.0f, 0.64f, 0.0f);
            text_ui_deliered_name.color = orange_color;
            text_ui_deliered.color = orange_color;
           // Debug.Log("DeliveredName and Deliverednumer should be Orange");

        }
        if (difffculyLevel == 3)
        {
            text_ui_deliered_name.color = Color.red;
            text_ui_deliered.color = Color.red;
        }
    }
    #endregion

    #region lives
    public void Displaylives(int lives)
    {
        text_ui_lives.text = lives.ToString();
    }
    #endregion

    #region Bench
    public void GetInfoOnBenchOverlap(string name, string money, float epiretime) 
    {
        bench_text_ui_deliered_name.text = name;
        bench_text_ui_deliered_money.text = money;
        bench_text_ui_deliered_epire.text = epiretime.ToString("F0")+ "sec";
    }
    public void HideBenchInfo()
    {
        bench_ui.SetActive(false);
    }
    public void ShowBenchInfo()
    {
        bench_ui.SetActive(true);
    }
    #endregion

    private void Update()
    {
        DisplayGameTimer();
    }
}
