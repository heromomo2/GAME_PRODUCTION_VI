using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem
{
    float current_score;

    int bonus_score = 5;

    int max_percentage, min_percentage, decent_percentage;

    // properties 
    public float Score
    {
        get
        {
            return current_score;
        }
        set
        {
            current_score = value;
        }
    }

    public int MaxPercentageBonus
    {
        get
        {
            return max_percentage;
        }
        set
        {
            max_percentage = value;
        }
    }
    public int MinPercentageBonus
    {
        get
        {
            return min_percentage;
        }
        set
        {
            min_percentage = value;
        }
    }
    public int DecentPercentageBonus
    {
        get
        {
            return min_percentage;
        }
        set
        {
            min_percentage = value;
        }
    }

    // Constructor
    public ScoreSystem(float score, int bonus_Score, int max_Percentage,  int decent_Percentage, int min_Percentage)
    {
        current_score = score;

        bonus_score = bonus_Score;

        max_percentage = max_Percentage;

        min_percentage = min_Percentage; 

       decent_percentage = decent_Percentage;
    }





    // method

    // add point
    public void AddToScore(item_type item)
    {
        if (item == item_type.pizza_box)
        {
            current_score += 13.99f;
        }
        else if (item == item_type.milk)
        {
            current_score += 2.99f;
        }
        else if (item == item_type.hambuger)
        {
            current_score += 10.99f;
        }
    }

    //check if you to reach the threshold for Bonus Points

    public void CheckForBonus(float left_time_to_delivery, float inital_delivery_time)
    {

        float minimal_percentage_bonus_point_threshold, decent_percentage_bonus_point_threshold, max_percentage_bonus_point_threshold;

        minimal_percentage_bonus_point_threshold = ((min_percentage / 100f )* inital_delivery_time);
        decent_percentage_bonus_point_threshold = ((decent_percentage /  100f) * inital_delivery_time);
        max_percentage_bonus_point_threshold = (( max_percentage /100f) * inital_delivery_time);

        if (max_percentage_bonus_point_threshold <= left_time_to_delivery )
        {
            current_score += bonus_score * 3;
            Debug.Log("you get bouns  max points on the delivery "+ "max_percentage_bonus_point_threshold-> "+ max_percentage_bonus_point_threshold);
        }
        else if (decent_percentage_bonus_point_threshold <= left_time_to_delivery && max_percentage_bonus_point_threshold > left_time_to_delivery )
        {
            current_score += bonus_score * 2;
            Debug.Log("you get bouns decent points on the delivery " + "decent_percentage_bonus_point_threshold -> " + decent_percentage_bonus_point_threshold);
        }
        else if (minimal_percentage_bonus_point_threshold <= left_time_to_delivery && decent_percentage_bonus_point_threshold >left_time_to_delivery )
        {
            current_score += bonus_score * 1;
            Debug.Log("you get min bouns points on the delivery " + "minimal_percentage_bonus_point_threshold -> " + minimal_percentage_bonus_point_threshold);
        }
        else
        {
            Debug.Log(" you didn't reach threshold");
        }
    }
}
