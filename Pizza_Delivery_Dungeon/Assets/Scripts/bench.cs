using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class bench : MonoBehaviour
{
    public List<GameObject> Benchpartslist;

    private Action<int> bench_event = null;

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
    }




}
