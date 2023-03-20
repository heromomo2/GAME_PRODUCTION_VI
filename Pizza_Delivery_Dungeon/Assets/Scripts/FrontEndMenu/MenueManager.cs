using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueManager : MonoBehaviour
{
    public static MenueManager Instance { get; private set; }
    public GameObject MainMenu = null;
    public GameObject LeaderBoard = null;
    public GameObject HowToPlay = null;
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
            return;
        }
        else 
        {
            Instance = this;
        }

        
    }
    private void Start()
    {

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.name == "MainMenu")
                MainMenu = go;
            else if (go.name == "LeaderBoard")
                LeaderBoard = go;
            else if (go.name == "HowToPlay")
                HowToPlay = go;
        }

    }

    //public void ChangeGState(int newState)
    //{
    //    switch (newState)
    //    {
    //        case GameStates.MainMenuState:
    //            main_menu.SetActive(true);
    //            leader_board.SetActive(false);
    //            SoundManager.Instance.PlayMusic();
    //            break;
    //        case GameStates.LeaderBoardState:
    //            main_menu.SetActive(false);
    //            leader_board.SetActive(true);
    //            SoundManager.Instance.StopMusic();
    //            break;
    //        case GameStates.PauseState:
    //            pause_menu.SetActive(true);
    //            SoundManager.Instance.PlayMusic();
    //            break;
    //        case GameStates.GamemodeState:
    //            is_game_over = false;
    //            pause_menu.SetActive(false);
    //            game_over.SetActive(false);
    //            SoundManager.Instance.StopMusic();
    //            break;
    //        case GameStates.GameOverState:
    //            is_game_over = true;
    //            pause_menu.SetActive(false);
    //            game_over.SetActive(true);
    //            break;

    //    }
  //  }

    static public class MenuState
    {
        public const int MainMenuState = 1;

        public const int LeaderBoardState = 2;

        public const int HowToPlayState = 5;

    }
}
