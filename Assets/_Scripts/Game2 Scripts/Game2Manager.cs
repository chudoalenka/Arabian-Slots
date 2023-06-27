using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Game2Manager : MonoBehaviour
{
    public static Game2Manager instance;
    public TMP_InputField inputField;
    public TextMeshProUGUI playerCollectedGold;
    public GameObject goldScrn;
    public int tempScoreCount;
    public TextMeshProUGUI scoretext;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        inputField.text = 100 + "";
    }

    public void goldScrnToggle()
    {
        goldScrn.SetActive(false);
    }

    public void ShowGoldScrn()
    {

        tempScoreCount = Convert.ToInt32(inputField.text);

        int tempVar = Convert.ToInt32(playerCollectedGold.text);

        scoretext.text = (tempScoreCount*2).ToString();

      //  tempScoreCount = tempScoreCount + tempVar;

        PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt+tempScoreCount*5);

        //playerCollectedGold.text = tempScoreCount.ToString();

        goldScrn.SetActive(true);

        GameManager.instance.CongratsEffectToggle();
    }

}
