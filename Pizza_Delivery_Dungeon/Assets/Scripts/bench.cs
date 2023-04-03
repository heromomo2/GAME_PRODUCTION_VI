using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class bench : MonoBehaviour
{
    public List<GameObject> Benchpartslist;

    private Action<int> bench_event = null;

    public benchpart hover_bench_part = null;

    public bool found_hover_bench_part = false;

    public bool bench_part_was_hover = false;

    [SerializeField] private HUD player_hud;

    public event Action<int> On_bench_event
    {
        add
        {
            bench_event -= value;
            bench_event += value;
        }

        remove
        {
            bench_event -= value;
        }
    }

    private void Start()
    {
        if (Benchpartslist.Count > 0) 
        {
            foreach(GameObject bp in Benchpartslist) 
            {
                if (bp.GetComponent<benchpart>()) 
                {
                    bp.GetComponent<benchpart>().On_bench_part_event += benchpartlinster;
                }

            }
        }
    }

    GameObject choose_Ai_Bench_part = null;
    void benchpartlinster(int i) 
    {
        if(i == 1) 
        {
            // spawn burger
            if (bench_event != null)
            {
                bench_event(1);
            }
            
        }
        else if (i == 2) 
        {
            // spawn burger
            if (bench_event != null)
            {
                bench_event(2);
            }
        }
        else if (i == 3)
        {
            // spawn burger
            if (bench_event != null)
            {
                bench_event(3);
            }
        }
        else if (i == 4)
        {
            //  food expicy on bench
            if (bench_event != null)
            {
                bench_event(4);
            }
        }
        else if (i == 5)
        {
            // playe have eneter trigger
            bench_part_was_hover = true;
            foundbenchpart();
        }
        else if (i == 6)
        {
            // playe have left the trigger
            bench_part_was_hover = false;
            Playerhasleave();
        }
    }


    private void Update()
    {
        
        info();
       
    }

    void foundbenchpart() 
    {
        if ( bench_part_was_hover == true)
        {
           if (hover_bench_part == null)
           {
              foreach (GameObject go in Benchpartslist)
                {
                Debug.Log("test 2: bechpart " + go.name);
                if (go.GetComponent<benchpart>() != null)
                {
                        if ( go.GetComponent<benchpart>().is_player_in_trigger) //go.AddComponent<benchpart>() != null &&
                        {
                            hover_bench_part = go.GetComponent<benchpart>();
                            Debug.Log(" test 1: bechpart " + go.name);
                            found_hover_bench_part = true;
                        }
                    }
                }
           }
        }
    }

    void info() 
    {
        if (hover_bench_part != null)
        {
            player_hud.GetInfoOnBenchOverlap(hover_bench_part.nameitem, hover_bench_part.itemcost, hover_bench_part.expiry_timer);
            player_hud.ShowBenchInfo();
        }
    }

    private void Playerhasleave()
    {
        if (bench_part_was_hover == false)
        {
            if (hover_bench_part != null)
            {
                foreach (GameObject go in Benchpartslist)
                {
                    if (go.GetComponent<benchpart>() != null)
                    {
                        if (!go.GetComponent<benchpart>().is_player_in_trigger)
                        {
                            hover_bench_part = null;
                            found_hover_bench_part = false;
                        }
                    }
                }
                player_hud.HideBenchInfo();
            }
        }
    }


    #region Ai function
    /// <summary>
    ///  Ai
    /// </summary>
    /// <returns></returns>
    /// 
    // check for empty space on the bench and pick the game object
    public bool CheckForEmptySpotOnBench() 
    {
        foreach (GameObject bp in Benchpartslist) 
        {
            if (!bp.GetComponent<benchpart>().do_we_have_an_item) 
            {
                choose_Ai_Bench_part = bp;
                return true;
            }
        }
        return false;
    }
    // the Ai will call this fuction
    public void PlaceitemOnBench(item_type item)
    {
        if (choose_Ai_Bench_part != null) 
        {
            if (choose_Ai_Bench_part.GetComponent<benchpart>())
            {
                choose_Ai_Bench_part.GetComponent<benchpart>().ChoseItem(item);
            }
        }
    }
    #endregion
}
