using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public GameObject Leader_board_return_button = null;
    public List<RankPlayerData> PlayerDatalist;
    public List<Text> Playernames;
    public List<Text> PlayerMoney;

    void Start()
    {
        
       GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.name == "LeaderBoardReturnButton")
                Leader_board_return_button = go;
          
        }
        PlayerDatalist = new List<RankPlayerData>();
        Leader_board_return_button.GetComponent<Button>().onClick.AddListener(LeaderBoardReturnButtonOnPress);
        GetLeaderBoardData();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LeaderBoardReturnButtonOnPress()
    {
        Debug.Log("ReturnButtonOnPress2");
        FrontEndMenuManager.Instance.our_menu_State = FrontEndMenuManager.FrontEndMenuState.MainMenuState;
        FrontEndMenuManager.ChangeFrontEndMenuState();
    }

    void GetLeaderBoardData()
    {
        Debug.Log("GetLeaderBoardData");

        if (GameData.Instance.RankPlayersDataCount() > 0)
        {
            GameData.Instance.CopyList(PlayerDatalist);

            for (int i = 0; i < PlayerDatalist.Count; i++)
            {
                if (i == 0)
                {
                    Playernames[i].text = "<color=black>"+(1 + i).ToString() + ")"+ PlayerDatalist[i].get_player_name_data().ToString() + "</color>";
                    PlayerMoney[i].text= "<color=black>" + "$" + PlayerDatalist[i].get_player_score_data().ToString() + "</color>";
                    Playernames[i].fontSize = 16;
                    PlayerMoney[i].fontSize = 16;
                }
                else
                {
                    Playernames[i].text = "<color=black>" + (1 + i).ToString() + ")" + PlayerDatalist[i].get_player_name_data().ToString() + "</color>";
                    PlayerMoney[i].text = "<color=black>" + "$"+ PlayerDatalist[i].get_player_score_data().ToString() + "</color>";
                }
            }
            Debug.Log("list_players_data.Count " + PlayerDatalist.Count.ToString());
        }

    }

}

