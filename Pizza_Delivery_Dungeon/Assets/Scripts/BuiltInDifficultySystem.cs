using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltInDifficultySystem
{
    int difficulty_counter;

    int difficuly_threshold_zero,difficuly_threshold_one, difficuly_threshold_two, difficuly_threshold_three;

    float speed_Increase_difficuly_for_delivery;

    float max_speed_difficuly;

    float min_speed_difficuly;

    float player_move_speed;

    float player_sprint_speed;

    int difficulty_level = 0;


    // properties 
    public int DifficultyCounter
    {
        get
        {
            return difficulty_counter;
        }
        set
        {
            difficulty_counter = value;
        }
    }


    public int DifficulyThresholdZero
    {
        get
        {
            return difficuly_threshold_zero;
        }
        set
        {
            difficuly_threshold_zero = value;
        }
    }

    public int DifficulyThresholdOne
    {
        get
        {
            return difficuly_threshold_one;
        }
        set
        {
            difficuly_threshold_one = value;
        }
    }

    public int DifficulyThresholdTwo
    {
        get
        {
            return difficuly_threshold_two;
        }
        set
        {
            difficuly_threshold_two = value;
        }
    }

    public int DifficulyThresholdThree
    {
        get
        {
            return difficuly_threshold_three;
        }
        set
        {
            difficuly_threshold_three = value;
        }
    }

    public float SpeedDifficuly
    {
        get
        {
            return speed_Increase_difficuly_for_delivery;
        }
        set
        {
            speed_Increase_difficuly_for_delivery = value;
        }
    }

    public float MaxSpeedDifficuly
    {
        get
        {
            return max_speed_difficuly;
        }
        set
        {
            max_speed_difficuly = value;
        }
    }

    public float MinSpeedDifficuly
    {
        get
        {
            return min_speed_difficuly;
        }
        set
        {
            max_speed_difficuly = value;
        }
    }


    public int DifficultyLevel
    {
        get
        {
            return difficulty_level;
        }
        set
        {
            difficulty_level = value;
        }
    }

    // Constructor
    public BuiltInDifficultySystem(int difficultyCounter, int Difficulythresholdzero, int Difficulythresholdone, int Difficulythresholdtwo, int Difficulythresholdthree, float Speeddifficuly, float Maxspeeddifficuly, float Minspeeddifficuly)
    {
        difficulty_counter = difficultyCounter;

        difficuly_threshold_zero = Difficulythresholdzero;

        difficuly_threshold_one = Difficulythresholdone;

        difficuly_threshold_two = Difficulythresholdtwo;

        difficuly_threshold_three = Difficulythresholdthree;

        speed_Increase_difficuly_for_delivery = Speeddifficuly;

        max_speed_difficuly = Maxspeeddifficuly;

        min_speed_difficuly = Minspeeddifficuly;
    }


    // method

    public void CheckForDifficuly()
    {
        difficulty_counter += 1;


         // have use the sprint to make delivers
        if (difficuly_threshold_three < difficulty_counter) 
        {
            float temp_max_speed = max_speed_difficuly / 4f; //   max_speed_difficuly =  7/ 4 =  1.75f

            min_speed_difficuly = (temp_max_speed + temp_max_speed + temp_max_speed);// 5.25f

            speed_Increase_difficuly_for_delivery = Random.Range(min_speed_difficuly, max_speed_difficuly);// ( 5.25f, 7f)
            Debug.Log(" you have reached the final diffiuly level " + " speed is now-> " + speed_Increase_difficuly_for_delivery);

            difficulty_level = 3;

        }// use the sprint to make delivers some of the time
        else if (difficuly_threshold_two < difficulty_counter && difficuly_threshold_three > difficulty_counter) 
        {
            float temp_max_speed = max_speed_difficuly / 4f; //   max_speed_difficuly =  7/ 4 =  1.75f

            min_speed_difficuly = (temp_max_speed + temp_max_speed); // (1.75 + 1.75) = 3.5)

            speed_Increase_difficuly_for_delivery = Random.Range(min_speed_difficuly, (temp_max_speed + temp_max_speed + temp_max_speed)); // ((3.5f, 5.25f)

            Debug.Log(" you have reached the second diffiuly level " + " speed is now-> " + speed_Increase_difficuly_for_delivery);

            difficulty_level = 2;

        }// 
        else if (difficuly_threshold_one < difficulty_counter && difficuly_threshold_two > difficulty_counter)
        {
            // one forth of clamp speed
            float temp_max_speed =  max_speed_difficuly / 4f; //   max_speed_difficuly =  7/ 4 =  1.75f

            min_speed_difficuly = player_move_speed; // 2f

            speed_Increase_difficuly_for_delivery = Random.Range(min_speed_difficuly, (temp_max_speed + temp_max_speed)); // ( 2f, (1.75 + 1.75) = 3.5)

            Debug.Log(" you have reached the first diffiuly level " + " speed is now-> " + speed_Increase_difficuly_for_delivery);

            difficulty_level = 1;
        }
        else if (difficuly_threshold_zero < difficulty_counter && difficuly_threshold_one > difficulty_counter)
        {
            // one forth of clamp speed
            min_speed_difficuly =  max_speed_difficuly / 4f; //   max_speed_difficuly =  7/ 4 =  1.75f

            speed_Increase_difficuly_for_delivery = Random.Range(min_speed_difficuly, player_move_speed ); //  (1.75f, player walk speed(2))

            Debug.Log(" you have reached the inital diffiuly level " + " speed is now-> " + speed_Increase_difficuly_for_delivery);

            difficulty_level = 0;
        }
    }
    
    // set up the clamp
    public void GetAverageSpeed() 
    {
        /// get average of these two number
        max_speed_difficuly = (player_sprint_speed + player_move_speed) / 2f; // (12 + 2) / 2 = 7

     //   Debug.Log("GetAverageSpeed() ");
    }

    //get player speeds
    public void GetPlayrSpeeds( float Playermovespeed, float Playersprintspeed)
    {
        player_move_speed = Playermovespeed;
        player_sprint_speed = Playersprintspeed;
    }
}
