using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public GameObject next_button = null;
    public GameObject back_button = null;
    public GameObject how_to_play_return_button = null;
    public GameObject page_number_text = null;
    public Text display_text = null;
    public Text second_title_text = null;
    public int pagenumber = 1;

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
            else if (go.name == "PageNumberText")
                page_number_text = go;

        }

        how_to_play_return_button.GetComponent<Button>().onClick.AddListener(HowToPlayReturnButtonOnPress);
        next_button.GetComponent<Button>().onClick.AddListener(NextButtonOnPress);
        back_button.GetComponent<Button>().onClick.AddListener(BackButtonOnPress);
        HowToPlayInfo(pagenumber);
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
        if (pagenumber < 7)
        {
            pagenumber += 1;
            HowToPlayInfo(pagenumber);
            
        }
        page_number_text.GetComponent<Text>().text = pagenumber + "/7 page number";
    }
    void BackButtonOnPress()
    {
        Debug.Log("BackButtonOnPres");
        if (pagenumber > 1)
        {
            pagenumber -= 1;
            HowToPlayInfo(pagenumber);
           
        }
        page_number_text.GetComponent<Text>().text = pagenumber + "/7 page number";
    }

    void HowToPlayInfo(int page_number)
    {
        switch (page_number)
        {
            case 1:
                second_title_text.text = "Your Goal";
                display_text.text = 
                    "Your goal is to deliver as many food items as possible." +
                    " Food items will be placed a top of these stands."
            + "These stands will be restocked by your alien pill form employer,and choose wisely which food item to deliver first.";
                break;
            case 2:
                second_title_text.text = "Your Goal";
                display_text.text = "Food items can expire on the stands or while you're carrying them." +
            "So you have to be fast!!" + "\n So you have to be fast!! Also, you will receive more points if you deliver things a lot earlier.";   

                break;
            case 3:
                second_title_text.text = "Controls";
                display_text.text = "Press: WASD to move around."
                    + "\n Press: the shift key to sprint, but  be aware you eat up stamina."
                    + "\n Press: the r key to do a roll, but be aware you will eat up stamina."
                    + "\n Press: the p key to pause the game.";
                    
                break;
            case 4:
                second_title_text.text = "Controls";
                display_text.text = "Press: the enter key to press the buttons on screen."
                    + "\n Press: the enter key to enter your when asked."
                    + "\n Press:  press e to pick up item from stands.";
                break;
            case 5:
                second_title_text.text = "Difficult";
                display_text.text = "The difficulty will increase with the more delivery you complete. It will be indicated by the colure of your Deliver count on the top."
                    + "\n - Black is easy."
                    + "\n - Green is less easy."
                    + "\n - Orange is not easy."
                    + "\n - Red is hard.";   

                break;
            case 6:
                second_title_text.text = "Difficult";
                display_text.text = "Watch for the spikes. They will remove your item from you and also remove your life. "+ 
                    "I advise you to use your sprint or roll to move around them..";
                break;
            case 7:
                second_title_text.text = "Fooditem";
                display_text.text = "All Food items will expire if not delivered, so watch the stands." + "Food items will give you points depending on what item it is." + "Also, the ice cream food item is the only item that will give you stamina back if you deliver it.";
                break;

        }
    }
}
