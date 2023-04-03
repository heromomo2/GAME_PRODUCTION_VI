using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMenuManager : MonoBehaviour
{
    public GameObject PauseMenu = null;
    public GameObject GameOver = null;
    public GameObject GameOverLeaderboard = null;

    public GamePlayMenuState our_menu_State = GamePlayMenuState.Gamemode;
    public static GamePlayMenuManager Instance { get; private set; }

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScene(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public static void ChangeGamePlayMenuState()
    {
        switch (Instance.our_menu_State)
        {
            case GamePlayMenuState.Gamemode:
                Instance.PauseMenu.SetActive(false);
                Instance.GameOver.SetActive(false);
                Instance.GameOverLeaderboard.SetActive(false);
                break;
            case GamePlayMenuState.Pause:
                Instance.PauseMenu.SetActive(true);
                Instance.GameOver.SetActive(false);
                Instance.GameOverLeaderboard.SetActive(false);
                break;
            case GamePlayMenuState.Gameover:
                Instance.PauseMenu.SetActive(false);
                Instance.GameOver.SetActive(true);
                Instance.GameOverLeaderboard.SetActive(false);
                break;
            case GamePlayMenuState.OverLeaderBoard:
                Instance.PauseMenu.SetActive(false);
                Instance.GameOver.SetActive(false);
                Instance.GameOverLeaderboard.SetActive(true); 
                break;
        }
    }
    public enum GamePlayMenuState
    {
        Gamemode,
         Pause,
        Gameover,
        OverLeaderBoard
    }
}
