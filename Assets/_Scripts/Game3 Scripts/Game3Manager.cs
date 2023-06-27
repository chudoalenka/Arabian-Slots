using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game3Manager : MonoBehaviour
{
    public static Game3Manager instance;
    public TMP_InputField inputField;
    public TextMeshProUGUI playerCollectedGold;
    public GameObject goldScrn;
    public TextMeshProUGUI scoretext;
    public GameObject dice1SelectionPanel, dice2SelectionPanel,dices;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        //int temp = Convert.ToInt32(playerCollectedGold.text);
        //temp += SaveSystem.instance.GetScorePlayerPrefs();
        //playerCollectedGold.text = temp.ToString();
        inputField.text = 1000 + "";
    }
    public void goldScrnToggle()
    {
        goldScrn.SetActive(false);
    }

    public void dice1Selector()
    {
        dice1SelectionPanel.SetActive(true);
        dices.SetActive(false);
        //BetSelectionPanel.SetActive(false);
    }

    public void dice2Selector()
    {
        dice2SelectionPanel.SetActive(true);
        dices.SetActive(false);

        //BetSelectionPanel.SetActive(false);
    }
}
