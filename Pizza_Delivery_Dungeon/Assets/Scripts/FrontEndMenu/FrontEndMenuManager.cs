using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrontEndMenuManager : MonoBehaviour
{
    public static FrontEndMenuManager Instance { get; private set; }
    public GameObject MainMenu = null;
    public GameObject LeaderBoard = null;
    public GameObject HowToPlay = null;

    public FrontEndMenuState our_menu_State = FrontEndMenuState.MainMenuState;
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
            if (go.name == "MainMenuCanvas")
                MainMenu = go;
            else if (go.name == "LeaderBoardCanvas")
                LeaderBoard = go;
            else if (go.name == "HowToPlayCanvas")
                HowToPlay = go;
        }

    }
    public void QuitButtonOnPress()
    {  
        Application.Quit();
    }
    public void OpenScene(string scenename) 
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public static void ChangeFrontEndMenuState()
    {
        switch (Instance.our_menu_State)
        {
            case FrontEndMenuState.MainMenuState:
                Instance.MainMenu.SetActive(true);
                Instance.MainMenu.GetComponent<MainMenu>().start_game_button.GetComponent<Button>().Select();
                Instance.LeaderBoard.SetActive(false);
                Instance.HowToPlay.SetActive(false);
                break;
            case FrontEndMenuState.LeaderBoardState:
                Instance.MainMenu.SetActive(false);
                Instance.LeaderBoard.SetActive(true);
                Instance.LeaderBoard.GetComponent<LeaderBoard>().Leader_board_return_button.GetComponent<Button>().Select();
                Instance.HowToPlay.SetActive(false);
                break;
            case FrontEndMenuState.HowToPlayState:
                Instance.MainMenu.SetActive(false);
                Instance.LeaderBoard.SetActive(false);
                Instance.HowToPlay.SetActive(true);
                Instance.HowToPlay.GetComponent<HowToPlay>().how_to_play_return_button.GetComponent<Button>().Select();
                break;
        }
    }

    public  enum FrontEndMenuState
    {
        MainMenuState,

        LeaderBoardState,

        HowToPlayState 
    }
}