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

    // Constructor
    public BuiltInDifficultySystem(int difficultyCounter, int Difficulythresholdzero, int Difficulythresholdone, int Difficulythresholdtwo, int Difficulythresholdthree, float Speeddifficuly, float Maxspeeddifficuly, float Minspeeddifficuly)
    {
        difficulty_counter = difficultyCounter;

        difficuly_threshold_zero = Difficulythresholdzero;

        difficuly_threshold_one = Difficulythresholdone;

        difficuly_threshold_two = Difficulythresholdone;

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

        }// use the sprint to make delivers some of the time
        else if (difficuly_threshold_two < difficulty_counter && difficuly_threshold_three > difficulty_counter) 
        {
            
        }// use  sprint rarly or don't need sprint 
        else if (difficuly_threshold_one < difficulty_counter && difficuly_threshold_two > difficulty_counter)
        {
            speed_Increase_difficuly_for_delivery = Random.Range(MinSpeedDifficuly, 3.0f);
            Debug.Log(" you have reached the first diffiuly level " + " speed is now-> " + speed_Increase_difficuly_for_delivery);
        }
        else if (difficuly_threshold_zero < difficulty_counter && difficuly_threshold_one > difficulty_counter)
        {
            speed_Increase_difficuly_for_delivery = Random.Range(1, min_speed_difficuly);
           Debug.Log(" you have reached the inital diffiuly level " + " speed is now-> " + speed_Increase_difficuly_for_delivery);
        }
    }
    

}
