using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Game3Spinner : MonoBehaviour
{
    public static Game3Spinner instance;

    public GameObject Dice1, Dice2,DiceCup, Dice1LeftPanel, Dice2RightPanel, LoseScrn,bttnspanel;

    public Transform dice1DefaultPos, dice2DefaultPos;

    public int[] selectedDices;

    int CoinsSelected;

    public static string PreDice1 = "6";

    public static string PreDice2 = "6";

    public static string DiceSelected1, DiceSelected2;
    public int dicee1, dicee2;
    int temp1, temp2,big,small; int winamount;
    public int d1value, d2value;
    int total;
    public Text totaltext;
    public GameObject totalimage;
    public GameObject win, lose,smalltext,bigtext;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        selectedDices[0] = 0;
        selectedDices[1] = 0;
        CoinsSelected = 1000;
    }
    private void Update()
    {
        d1value = DiceDetector.D1Value;
        d2value = DiceDetector.D2Value;
    }
    public void On_Dice_Selector1_Value_Changed(string diceNumber)
    {
        DiceSelected1 = diceNumber;
        selectedDices[0] = Convert.ToInt32(diceNumber);
        Game3Manager.instance.dice1SelectionPanel.SetActive(false);
        Dice1LeftPanel.transform.Find(PreDice1).gameObject.SetActive(false);
        Dice1LeftPanel.transform.Find(DiceSelected1).gameObject.SetActive(true);
        PreDice1 = DiceSelected1;
        Dice1.SetActive(true);
        Dice2.SetActive(true);
        DiceCup.SetActive(true);
    }

    public void On_Dice_Selector2_Value_Changed(string diceNumber)
    {
        DiceSelected2 = diceNumber;
        selectedDices[1] = Convert.ToInt32(diceNumber);
        Game3Manager.instance.dice2SelectionPanel.SetActive(false);
        Dice2RightPanel.transform.Find(PreDice2).gameObject.SetActive(false);
        Dice2RightPanel.transform.Find(DiceSelected2).gameObject.SetActive(true);
        PreDice2 = DiceSelected2;
        Dice1.SetActive(true);
        Dice2.SetActive(true);
        DiceCup.SetActive(true);
    }
	public void Reset()
	{
         temp1 = UnityEngine.Random.Range(1, 7);
         temp2 = UnityEngine.Random.Range(1, 7);
        StartCoroutine(ColliderNumbering());
       // IsPlayerWinOrNot();
	}
    public void Big()
    {
        big = 1;
        small = 0;
        bigtext.SetActive(false);
        bigtext.SetActive(true);
    }
    public void Small()
    {
        big = 0;
        small = 1;
        smalltext.SetActive(false);
        smalltext.SetActive(true);
    }
    public void IsPlayerWinOrNot()
    {

        //if ((selectedDices[0] == DiceDetector.D1Value && selectedDices[1] == DiceDetector.D2Value)
        //    || (selectedDices[1] == DiceDetector.D1Value && selectedDices[0] == DiceDetector.D2Value))
        dicee1 = DiceDetector.D1Value;
        dicee2 = DiceDetector.D2Value;
        total = DiceDetector.D1Value + DiceDetector.D2Value;
        totalimage.SetActive(true);
        totaltext.text = total + "";
        if (total != 7) 
        {
            Debug.Log("Player Win!!");

        int tempScoreCount = Convert.ToInt32(Game3Manager.instance.inputField.text);
            
            if (big == 1&& total > 7)
            {
                winamount = tempScoreCount+1000;
            }
          else if (small == 1 && total < 7)
            {
                winamount = tempScoreCount + 1000;
            }
            else
            {
                Invoke("hide", 3f);
                StartCoroutine(IsDiceAnimationRunning());
                return;
            }
            int tempVar = Convert.ToInt32(Game3Manager.instance.playerCollectedGold.text);

        Game3Manager.instance.scoretext.text = (winamount).ToString();

        Game3Manager.instance.playerCollectedGold.text += tempScoreCount.ToString();

            //   Game3Manager.instance.goldScrn.SetActive(true);
            Invoke("Win", 1);
            
        PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt + winamount);
        }
        else
        {
            Invoke("hide", 3f);
            StartCoroutine(IsDiceAnimationRunning());
        }
    }

    void Win()
    {
        Invoke("hide", 3f);
        win.SetActive(true);
    }
    void hide()
    {
        totalimage.SetActive(false);
        totaltext.text = "";
        win.SetActive(false);
        lose.SetActive(false);
        Dice1.SetActive(true); Dice2.SetActive(true);
        bttnspanel.SetActive(true);
        smalltext.SetActive(false);
        bigtext.SetActive(false);
    }
    private IEnumerator IsDiceAnimationRunning()
    {       
        yield return new WaitForSeconds(1f);
        Debug.Log("Player Lost..");
        lose.SetActive(true);
      //  LoseScrn.SetActive(true);
        SoundManager.instance.GameBgSound();
    }
    private IEnumerator ColliderNumbering()
    {
        yield return new WaitForSeconds(3f);
    }
    public void AutoBet()
    {
        CoinsSelected = 10000;
        bttnspanel.SetActive(false);

        if (GameManager.playerGoldInt < CoinsSelected)
        {
            GameManager.instance.ShopPopUpToggle(true);
            return;
        }
        Game3Manager.instance.inputField.text = CoinsSelected.ToString();
        SpinFunc();
    }
    public void ResetInputField()
    {
        int temp = 10000;
        CoinsSelected = temp;
        Game3Manager.instance.inputField.text = temp.ToString();
    }

    public void MinInputField()
    {
        int temp = 10000;
        CoinsSelected = temp;
        Game3Manager.instance.inputField.text = temp.ToString();
    }

    public void MaxInputField()
    {
        int temp = 30000;
        CoinsSelected = temp;
        Game3Manager.instance.inputField.text = temp.ToString();
    }

    public void gold100InputField()
    {
        int temp = 10000;
        CoinsSelected = temp;
        Game3Manager.instance.inputField.text = temp.ToString();
    }

    public void gold200InputField()
    {
        int temp = 20000;
        CoinsSelected = temp;
        Game3Manager.instance.inputField.text = temp.ToString();
    }

    public void gold300InputField()
    {
        int temp = 30000;
        CoinsSelected = temp;
        Game3Manager.instance.inputField.text = temp.ToString();
    }

    public void MinusBet()
    {
        int temp = Convert.ToInt32(Game3Manager.instance.inputField.text);
        temp -= 1000;

        if (temp < 1000)
        {
            temp = 1000;
        }
        CoinsSelected = temp;
        Game3Manager.instance.inputField.text = temp.ToString();
    }

    public void PlusBet()
    {
        int temp = Convert.ToInt32(Game3Manager.instance.inputField.text);

        temp += 1000;

        if (temp > 30000)
        {
            temp = 30000;
        }
        CoinsSelected = temp;
        Game3Manager.instance.inputField.text = temp.ToString();
    }

    public void SpinFunc()
    {
        
        bttnspanel.SetActive(false);

        int temp = Convert.ToInt32(Game3Manager.instance.inputField.text);

        int goldInt = GameManager.playerGoldInt - CoinsSelected;

        if (GameManager.playerGoldInt < 1000)
        {
            GameManager.instance.ShopPopUpToggle(true);
            return;
        }

        if (goldInt < 0)
        {
            goldInt = 0;
        }

        PlayerPrefs.SetInt("NewAllGold", goldInt);
        if ((temp < 1000 || temp > 30000) && selectedDices[0] == 0 && selectedDices[1] == 0)
        {
            return;
        }
    //    Reset();
    }
    public void Okay()
    {
        Dice1.SetActive(true); Dice2.SetActive(true);

    }
}

