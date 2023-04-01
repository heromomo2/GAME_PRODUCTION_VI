using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public GameObject next_button = null;
    public GameObject back_button = null;
    public GameObject how_to_play_return_button = null;
    public GameObject page_number = null;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.name == "HowToPlayReturnButton")
                how_to_play_return_button = go;
            else if (go.name == "NextButton")
                next_button = go;
            else if (go.name == "BackButton")
                back_button = go;
            else  if (go.name == "PageNumberText")
                page_number = go;
           
        }

        how_to_play_return_button.GetComponent<Button>().onClick.AddListener(HowToPlayReturnButtonOnPress);
        next_button.GetComponent<Button>().onClick.AddListener(NextButtonOnPress);
        back_button.GetComponent<Button>().onClick.AddListener(BackButtonOnPress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HowToPlayReturnButtonOnPress()
    {
        Debug.Log("ReturnButtonOnPress");
        FrontEndMenuManager.Instance.our_menu_State = FrontEndMenuManager.FrontEndMenuState.MainMenuState;
        FrontEndMenuManager.ChangeFrontEndMenuState();
    }
    void NextButtonOnPress()
    {
        Debug.Log("NextButtonOnPress");
    }
    void BackButtonOnPress()
    {
        Debug.Log("BackButtonOnPres");
    }
}
