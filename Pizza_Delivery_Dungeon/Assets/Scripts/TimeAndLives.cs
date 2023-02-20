using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndLives
{
    // lives
    int lives;

    // time
    float game_start_time;

    float game_current_time = 0f;

    float minutes;

    float seconds;


    // properties 
    public int Playerlives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }

    public float GameTimer
    {
        get
        {
            return game_current_time;
        }
        set
        {
            game_current_time = value;
        }
    }

    public float GameStartTime
{
        get
        {
            return game_start_time;
        }
        set
        {
            game_start_time = value;
        }
    }

    public float GetGameTimerMinute
    {
        get
        {
            return minutes;
        }
        set
        {
            minutes = value;
        }
    }

    public float GetGameTimerSeconds
    {
        get
        {
            return seconds;
        }
        set
        {
            seconds = value;
        }
    }


    // Constructor
    public TimeAndLives(int Playerlives, float Gamestarttime)
    {
        lives = Playerlives;
        game_start_time = Gamestarttime;

        // start set up the game timer
        game_current_time = game_start_time;
    }



    #region lives method

    public void RemoveALife()
    {
        if ( lives > 0)
        {
            lives -= 1;
        }
    }
    #endregion

    #region Time method

    public void GameTimerUpDate() 
    {
        minutes = Mathf.FloorToInt(game_current_time / 60);
        seconds = Mathf.FloorToInt(game_current_time % 60);
    }
    #endregion
}
