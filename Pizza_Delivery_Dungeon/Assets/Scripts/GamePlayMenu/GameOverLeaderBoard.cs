using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverLeaderBoard : MonoBehaviour
{
    public GameObject game_over_leader_board_continue_button = null;
    public List<Text> leader_money_texts;
    public List<Text> leader_name_texts;
    public List<RankPlayerData> game_over_leader_board_list_players_data;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.name == "GameOverLeaderBoardContinueButton")
                game_over_leader_board_continue_button = go;
            

        }

        game_over_leader_board_continue_button.GetComponent<Button>().onClick.AddListener(GameOverLeaderBoardContinueButtonOnPress);

        //leader_texts = new[5] Text;
        //int i = 0;
        //while (i < 5 )
        //{
        //    Text temp;

        //    temp = GameObject.Find("PlayerText"+i).gameObject.GetComponent<Text>();
        //    leader_texts[i] = temp;
        //    i++;

        //}

        game_over_leader_board_list_players_data = new List<RankPlayerData>();
        this.gameObject.SetActive(false);
    }

    public void UpdateGameOverLeaderBoard()
    {
        game_over_leader_board_list_players_data = new List<RankPlayerData>();

        GameData.Instance.CopyList(game_over_leader_board_list_players_data);

        if (GameData.Instance.RankPlayersDataCount() > 0)
        {
            GameData.Instance.CopyList(game_over_leader_board_list_players_data);

            for (int i = 0; i < game_over_leader_board_list_players_data.Count; i++)
            {
                if (i == 0)
                {
                    leader_name_texts[i].text = "<color=black>" + (1 + i).ToString() + ")" + game_over_leader_board_list_players_data[i].get_player_name_data().ToString() + "</color>";
                    leader_money_texts[i].text = "<color=black>" + "$" + game_over_leader_board_list_players_data[i].get_player_score_data().ToString() + "</color>";

                }
                else
                {
                    leader_name_texts[i].text = "<color=black>" + (1 + i).ToString() + ")" + game_over_leader_board_list_players_data[i].get_player_name_data().ToString() + "</color>";
                    leader_money_texts[i].text = "<color=black>" + "$" + game_over_leader_board_list_players_data[i].get_player_score_data().ToString() + "</color>";
                }
            }

        }
    }
    void GameOverLeaderBoardContinueButtonOnPress()
    {
        Debug.Log("PauseQuitButtonOnPress");
        Time.timeScale = 1f;
        GamePlayMenuManager.Instance.OpenScene("mainmenu");
    }
}
