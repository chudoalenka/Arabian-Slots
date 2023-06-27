using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game4Manager : MonoBehaviour
{
    public static Game4Manager instance;
    public TMP_InputField inputField;
    public TextMeshProUGUI playerCollectedGold;
    public GameObject goldScrn,losescr;
    public int tempScoreCount;
    public TextMeshProUGUI scoretext;
    int winningAmount;

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
        inputField.text = 100 + "";
    }

    public void goldScrnToggle()
    {
        goldScrn.SetActive(false);
    }

    public void ShowGoldScrn()
    {

        //string luckySpinString = Game4Spinner.num1 + Game4Spinner.num2 + Game4Spinner.num3;

        tempScoreCount = Convert.ToInt32(inputField.text);

        

        //tempScoreCount = tempScoreCount + tempVar;

        //  PlayerPrefs.SetInt("AllGold", GameManager.playerGoldInt+tempScoreCount);

        //scoretext.text = tempScoreCount.ToString();

        //tempVar = Convert.ToInt32(playerCollectedGold.text);

        //tempScoreCount = tempScoreCount + tempVar;

        if(tempScoreCount > 99999999)
        {
            tempScoreCount = 99999999;
        }
        if(Game4Spinner.holder1ImageIndex==Game4Spinner.holder2ImageIndex && Game4Spinner.holder1ImageIndex==Game4Spinner.holder3ImageIndex)
        {

            goldScrn.SetActive(true);
            GameManager.instance.CongratsEffectToggle();
            if (Game4Spinner.holder1ImageIndex == 0)
            {
                PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt + tempScoreCount * 3);
                winningAmount = tempScoreCount * 3;
            }
            else if (Game4Spinner.holder1ImageIndex == 1)
            {
                PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt + tempScoreCount * 5);
                winningAmount = tempScoreCount * 5;
            }
            else if (Game4Spinner.holder1ImageIndex == 2)
            {
                PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt + tempScoreCount * 2);
                winningAmount = tempScoreCount * 2;
            }
            else if (Game4Spinner.holder1ImageIndex == 3)
            {
                PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt + tempScoreCount * 4);
                winningAmount = tempScoreCount * 4;
            }
            else if (Game4Spinner.holder1ImageIndex == 4)
            {
                PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt + tempScoreCount * 10);
                winningAmount = tempScoreCount * 10;
            }
            else if (Game4Spinner.holder1ImageIndex == 5)
            {
                PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt + tempScoreCount * 50);
                winningAmount = tempScoreCount * 50;
            }
            else if (Game4Spinner.holder1ImageIndex == 6)
            {
                PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt + tempScoreCount * 20);
                winningAmount = tempScoreCount * 20;
            }
            scoretext.text = winningAmount.ToString();
            goldScrn.SetActive(true);
            playerCollectedGold.text = PlayerPrefs.GetInt("NewAllGold").ToString();

        }
        else if (Game4Spinner.holder1ImageIndex == 5 && Game4Spinner.holder2ImageIndex == Game4Spinner.holder3ImageIndex || Game4Spinner.holder2ImageIndex == 5 && Game4Spinner.holder1ImageIndex == Game4Spinner.holder3ImageIndex || Game4Spinner.holder3ImageIndex == 5 && Game4Spinner.holder1ImageIndex == Game4Spinner.holder2ImageIndex)
        {
            winningAmount = tempScoreCount * 30;
            scoretext.text = winningAmount.ToString();
            goldScrn.SetActive(true);
            playerCollectedGold.text = PlayerPrefs.GetInt("NewAllGold").ToString();
        }
        else if (Game4Spinner.holder1ImageIndex == 5 && Game4Spinner.holder2ImageIndex == 5 || Game4Spinner.holder2ImageIndex == 5 && Game4Spinner.holder3ImageIndex == 5 || Game4Spinner.holder3ImageIndex == 5 && Game4Spinner.holder1ImageIndex == 5)
        {
            winningAmount = tempScoreCount * 30;
            scoretext.text = winningAmount.ToString();
            goldScrn.SetActive(true);
            playerCollectedGold.text = PlayerPrefs.GetInt("NewAllGold").ToString();
        }
        else
        {
            losescr.SetActive(true);
        }
        
        
    }
}
