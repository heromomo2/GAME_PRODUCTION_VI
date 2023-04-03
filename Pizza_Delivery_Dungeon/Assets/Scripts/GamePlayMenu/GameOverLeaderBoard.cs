using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverLeaderBoard : MonoBehaviour
{
    public GameObject game_over_leader_board_continue_button = null;
    public Text[] leader_texts;
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
        

        this.gameObject.SetActive(false);
    }

    public void UpdateGameOverLeaderBoard()
    {
        game_over_leader_board_list_players_data = new List<RankPlayerData>();
        GameData.Instance.CopyList(game_over_leader_board_list_players_data);
        for (int i = 0; i< leader_texts.Length; i++)
        {
            leader_texts[i].text = "<color=cyan>" + (1 + i).ToString() + ")" + game_over_leader_board_list_players_data[i].get_player_name_data().ToString() + "</color>" + " " + "<color=yellow>" + game_over_leader_board_list_players_data[i].get_player_score_data().ToString() + "</color>"; 
        }
    }
    void GameOverLeaderBoardContinueButtonOnPress()
    {
        Debug.Log("PauseQuitButtonOnPress");
        Time.timeScale = 1f;
        GamePlayMenuManager.Instance.OpenScene("mainmenu");
    }
}
