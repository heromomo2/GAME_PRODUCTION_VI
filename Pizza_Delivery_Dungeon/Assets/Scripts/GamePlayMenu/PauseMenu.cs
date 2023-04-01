using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public GameObject pause_resure_button = null;
    public GameObject pause_quit_button = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.name == "LeaderBoardReturnButton")
                pause_resure_button = go;
            else if (go.name == "NextButton")
                pause_quit_button = go;

        }
        pause_resure_button.GetComponent<Button>().onClick.AddListener(PauseResureButtonOnPress);
        pause_quit_button.GetComponent<Button>().onClick.AddListener(PauseQuitButtonOnPress);
        this.gameObject.SetActive(false);
    }
    void PauseResureButtonOnPress()
    {
        Debug.Log("PauseResureButtonOnPress");
        Time.timeScale = 1f;
        GamePlayMenuManager.Instance.our_menu_State = GamePlayMenuManager.GamePlayMenuState.Gamemode;
        GamePlayMenuManager.ChangeGamePlayMenuState();
    }
    void PauseQuitButtonOnPress()
    {
        Debug.Log("PauseQuitButtonOnPress");
        Time.timeScale = 1f;
        GamePlayMenuManager.Instance.OpenScene("mainmenu");
    }
    
}
