using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseItemData : MonoBehaviour
{
    public Image ItemSprit;
    public TextMeshProUGUI ItemCount;



    private void Awake()
    {
        ItemSprit.color = Color.clear;
        ItemCount.text = "";
    }
}
