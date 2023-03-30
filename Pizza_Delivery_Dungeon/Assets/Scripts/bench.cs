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
                if (bp.AddComponent<benchpart>()) 
                {
                    bp.AddComponent<benchpart>().On_bench_part_event += benchpartlinster;
                }

            }
        }
    }

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
        }
        else if (i == 6)
        {
            // playe have left the trigger
        }
    }


    private void Update()
    {
        //if (found_hover_bench_part == false)
        //{
        //    if (hover_bench_part == null)
        //    {
        //        foreach (GameObject go in Benchpartslist)
        //        {
        //            if (go.AddComponent<benchpart>())
        //            {
        //                if (go.AddComponent<benchpart>() != null && go.AddComponent<benchpart>().is_player_in_trigger)
        //                {
        //                    hover_bench_part = go.AddComponent<benchpart>();
        //                    found_hover_bench_part = true;
        //                }
        //            }
        //        }
        //    }
        //        if (hover_bench_part != null)
        //        {
        //            player_hud.GetInfoOnBenchOverlap(hover_bench_part.nameitem, hover_bench_part.itemcost, hover_bench_part.expiry_timer);
        //            player_hud.ShowBenchInfo();
        //        } 
            
        //}
        //else
        //{
        //    foreach (GameObject go in Benchpartslist)
        //    {
        //        if (go.AddComponent<benchpart>() != null)
        //        {
        //            if (!go.AddComponent<benchpart>().is_player_in_trigger)
        //            {
        //                hover_bench_part = null;
        //                found_hover_bench_part = false;
        //            }
        //        }
        //    }
        //    player_hud.HideBenchInfo();
        //}
    }

    void foundbenchpart() 
    {
        if (hover_bench_part == null)
        {
            foreach (GameObject go in Benchpartslist)
            {
                if (go.AddComponent<benchpart>())
                {
                    if (go.AddComponent<benchpart>() != null && go.AddComponent<benchpart>().is_player_in_trigger)
                    {
                        hover_bench_part = go.AddComponent<benchpart>();
                        found_hover_bench_part = true;
                    }
                }
            }
        }
        if (hover_bench_part != null)
        {
            player_hud.GetInfoOnBenchOverlap(hover_bench_part.nameitem, hover_bench_part.itemcost, hover_bench_part.expiry_timer);
            player_hud.ShowBenchInfo();
        }
    }


}
