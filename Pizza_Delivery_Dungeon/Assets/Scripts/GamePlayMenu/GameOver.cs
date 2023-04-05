using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject game_over_continue_button = null;
    public GameObject game_over_eneter_button = null;
    public GameObject game_over_input_Field = null;
    public GameObject game_over_text = null;
    public string name = null;
    public float score = -1;

    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.name == "EnterButton")
                game_over_eneter_button = go;
            else if (go.name == "ContinueButton")
                game_over_continue_button = go;

        }
        game_over_continue_button.GetComponent<Button>().onClick.AddListener(GameOverContinueButtonOnPress);
        game_over_eneter_button.GetComponent<Button>().onClick.AddListener(GameOverEnterButtonOnPress);
        this.gameObject.SetActive(false);
    }

    public void GameOverInitial(bool did_we_get_a_high_score) 
    {
        if (did_we_get_a_high_score) 
        {
            game_over_text.GetComponent<Text>().text = "Thank you for playing.Please enter your name blow.";
            game_over_input_Field.SetActive(true);
            game_over_eneter_button.SetActive(true);
            game_over_continue_button.SetActive(false);
            game_over_eneter_button.GetComponent<Button>().Select();
        }
        else 
        {
            game_over_text.GetComponent<Text>().text = "Thank you for playing, But you didn't get a highscore.";
            game_over_input_Field.SetActive(false);
            game_over_eneter_button.SetActive(false);
            game_over_continue_button.SetActive(true);
            game_over_continue_button.GetComponent<Button>().Select();
        }
    }



    void  GameOverEnterButtonOnPress()
    {
        name = game_over_input_Field.GetComponent<InputField>().text.ToString();

        if (name != null && score != -1)
        {
            GameData.Instance.AddPlayerDataToRankPlayersData(new RankPlayerData(name, score));
            GameData.Instance.SaveAllRankPlayersData();
        }

        GamePlayMenuManager.Instance.our_menu_State = GamePlayMenuManager.GamePlayMenuState.OverLeaderBoard;
        GamePlayMenuManager.ChangeGamePlayMenuState();
        GamePlayMenuManager.Instance.GameOverLeaderboard.GetComponent<GameOverLeaderBoard>().UpdateGameOverLeaderBoard();
        GamePlayMenuManager.Instance.GameOverLeaderboard.GetComponent<GameOverLeaderBoard>().game_over_leader_board_continue_button.GetComponent<Button>().Select();
    }
    void GameOverContinueButtonOnPress()
    {
        GamePlayMenuManager.Instance.our_menu_State = GamePlayMenuManager.GamePlayMenuState.OverLeaderBoard;
        GamePlayMenuManager.Instance.GameOverLeaderboard.GetComponent<GameOverLeaderBoard>().UpdateGameOverLeaderBoard();
        GamePlayMenuManager.Instance.GameOverLeaderboard.GetComponent<GameOverLeaderBoard>().game_over_leader_board_continue_button.GetComponent<Button>().Select();
        GamePlayMenuManager.ChangeGamePlayMenuState();
    }

}
