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


    //public float GameTimer
    //{
    //    get
    //    {
    //        return game_timer;
    //    }
    //    set
    //    {
    //        game_timer = value;
    //    }
    //}

    //public float GameTime
    //{
    //    get
    //    {
    //        return game_time;
    //    }
    //    set
    //    {
    //        game_time = value;
    //    }
    //}


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
    }
}
