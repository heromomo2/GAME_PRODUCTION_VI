using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public GameObject Leader_board_return_button = null;
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

        Leader_board_return_button.GetComponent<Button>().onClick.AddListener(LeaderBoardReturnButtonOnPress);
       
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
   
    
}
