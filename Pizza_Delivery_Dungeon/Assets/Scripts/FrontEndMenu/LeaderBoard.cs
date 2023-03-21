using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public GameObject return_button = null;
    public List<Text> Playernames;
    public List<Text> PlayerMoney;

    void Start()
    {

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.name == "ReturnButton1")
                return_button = go;
          
        }

        return_button.GetComponent<Button>().onClick.AddListener(ReturnButtonOnPress);
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ReturnButtonOnPress()
    {
        Debug.Log("ReturnButtonOnPress2");
        MenueManager.Instance.our_menu_State = MenueManager.MenuState.MainMenuState;
        MenueManager.ChangeMenuState();
    }
   
    
}
