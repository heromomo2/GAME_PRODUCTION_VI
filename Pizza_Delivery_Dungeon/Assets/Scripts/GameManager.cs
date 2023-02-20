using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager game_manager { get; private set; }

    public UnitStamina player_stamina = new UnitStamina(100f, 100f, 30f, false, 25f, false, 10.0f );
    public ScoreSystem player_score = new ScoreSystem ( 0f, 5, 70, 60, 50);
    public BuiltInDifficultySystem built_In_difficulty = new BuiltInDifficultySystem(0,0,5,10, 15,2,0,0);

  [SerializeField]  float game_timer;
    [SerializeField] float game_time = 20.99f;
    public float GameTimer
    {
        get
        {
            return game_timer;
        }
        set
        {
            game_timer = value;
        }
    }

    public float GameTime
    {
        get
        {
            return game_time;
        }
        set
        {
            game_time = value;
        }
    }


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
        game_timer = game_time;
    }

    private void Update()
    {
        if (game_timer > 0) 
        {
            game_timer -= 1 * Time.deltaTime;

        }
    }
}
