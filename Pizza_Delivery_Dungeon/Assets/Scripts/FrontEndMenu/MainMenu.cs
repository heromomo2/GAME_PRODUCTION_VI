using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject start_game_button = null;
    public GameObject leader_board_button = null;
    public GameObject How_To_Play_button = null;
    public GameObject Quit_button = null;
    void Start()
    {

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.name == "LeaderBoardButton")
                leader_board_button = go;
            else if (go.name == "StartGameButton")
                start_game_button = go;
            else if (go.name == "HowToPlayButton")
                How_To_Play_button = go;
            else if (go.name == "QuitButton")
                Quit_button = go;
        }

        leader_board_button.GetComponent<Button>().onClick.AddListener(LeaderBoardButtonOnPress);
        start_game_button.GetComponent<Button>().onClick.AddListener(StartGameButtonOnPress);
        How_To_Play_button.GetComponent<Button>().onClick.AddListener(HowToPlayButtonOnPress);
        Quit_button.GetComponent<Button>().onClick.AddListener(QuitButtionOnPress);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGameButtonOnPress()
    {
          Debug.Log("StartGameButtonOnPress");
        MenueManager.Instance.OpenScene("SampleScene");
    }
    void HowToPlayButtonOnPress()
    {
        Debug.Log("HowToPlayButtonPress");
        MenueManager.Instance.our_menu_State = MenueManager.MenuState.HowToPlayState;
        MenueManager.ChangeMenuState();
    }
    void LeaderBoardButtonOnPress()
    {
        Debug.Log("LeaderBoardButtonOnPress");
        MenueManager.Instance.our_menu_State = MenueManager.MenuState.LeaderBoardState;
        MenueManager.ChangeMenuState();
    }
    
    void QuitButtionOnPress()
    {
        Debug.Log("QuitButtionOnPress");
        MenueManager.Instance.QuitButtonOnPress();
    }
}