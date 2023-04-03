using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager game_manager { get; private set; }

    public UnitStamina player_stamina = new UnitStamina(100f, 100f, 30f, false, 25f, false, 10.0f );

    public ScoreSystem player_score = new ScoreSystem ( 0f, 5, 70, 60, 50);

    public BuiltInDifficultySystem built_In_difficulty = new BuiltInDifficultySystem(0,0,5,10, 15,2,0,0);


    public TimeAndLives time_and_lives = new  TimeAndLives(3, 900);

    public float carry_item_timer = 0f;

    public GameObject gameover;

    public bool is_game_over = false;

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

    private void Start()
    {
        
    }

    private void Update()
    {
        if (time_and_lives.GameTimer > 0) 
        {
            time_and_lives.GameTimer -= Time.deltaTime;
        }
        else 
        {
            time_and_lives.GameTimer = 0;
        }

        time_and_lives.GameTimerUpDate();

        /// game over stuff
        if (time_and_lives.Playerlives <= 0) 
        {
            Debug.Log("you have no more lives");
           
            // checking your score
            if (GameData.Instance.IsYourScoreRankWorthy(player_score.Score))
            {
                if (gameover!= null && gameover.GetComponent<GameOver>() != null && !is_game_over ) 
                {
                    if (GamePlayMenuManager.Instance.our_menu_State != GamePlayMenuManager.GamePlayMenuState.Gameover)
                    {
                        gameover.GetComponent<GameOver>().GameOverInitial(true);
                        GamePlayMenuManager.Instance.our_menu_State = GamePlayMenuManager.GamePlayMenuState.Gameover;
                        GamePlayMenuManager.ChangeGamePlayMenuState();
                        gameover.GetComponent<GameOver>().score = player_score.Score;
                        is_game_over = true;
                        Time.timeScale = 0;
                    }
                }
            }
            else 
            {
                if (gameover != null && gameover.GetComponent<GameOver>() != null && !is_game_over)
                {
                    if (GamePlayMenuManager.Instance.our_menu_State != GamePlayMenuManager.GamePlayMenuState.Gameover)
                    {
                        gameover.GetComponent<GameOver>().GameOverInitial(false);
                        GamePlayMenuManager.Instance.our_menu_State = GamePlayMenuManager.GamePlayMenuState.Gameover;
                        GamePlayMenuManager.ChangeGamePlayMenuState();
                        is_game_over = true;
                        Time.timeScale = 0;
                    }
                    
                }
            }
            
        }
        
    }



}
