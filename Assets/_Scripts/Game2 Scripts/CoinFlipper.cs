using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CoinFlipper : MonoBehaviour, IDragHandler
{
    public int headOrTail = 0, userSelected;

    public Animator anim;

    public GameObject[] coins; //Coin 0 Main Coin then Heads and then tails.

    int CoinsSelected;

    public GameObject losescr,BttnsPanel;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
        //coins = new GameObject[3]; 
        CoinsSelected = 100;
    }

    public void FlipCoin()
    {
        BttnsPanel.SetActive(false);
        int temp = Convert.ToInt32(Game2Manager.instance.inputField.text);

        if (GameManager.playerGoldInt < 100)
        {
            GameManager.instance.ShopPopUpToggle(true);
            return;
        }

        if (temp < 100 || temp > 30000)
        {
            return;
        }
        coins[1].SetActive(false);
        coins[2].SetActive(false);
        int tempHeadOrTail = UnityEngine.Random.Range(1, 3);
        headOrTail = tempHeadOrTail;
        anim.speed = 1;
        Invoke("StopCoin", 2.5f);
        int goldInt = GameManager.playerGoldInt - CoinsSelected;

        if (goldInt < 0)
        {
            goldInt = 0;
        }
        PlayerPrefs.SetInt("NewAllGold", goldInt);
        SoundManager.instance.Game2CoinSound();
    }

    public void StopCoin()
    {
        anim.speed = 0;
        
        coins[headOrTail].SetActive(true);

        if (userSelected == headOrTail)
        {
            Game2Manager.instance.ShowGoldScrn();
        }
        else
        {
            losescr.SetActive(true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        FlipCoin();
    }

    public void ResetGame()
    {
        coins[1].SetActive(false);
        coins[2].SetActive(false);

        int temp = 100;
        Game2Manager.instance.inputField.text = temp.ToString();
    }


    public void AutoBet()
    {
        int temp = 200;

        if (GameManager.playerGoldInt < temp)
        {
            GameManager.instance.ShopPopUpToggle(true);
            return;
        }

        Game2Manager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
        FlipCoin();
    }

    public void MinInputField()
    {
        int temp = 100;
        CoinsSelected = temp;
        Game2Manager.instance.inputField.text = temp.ToString();
    }

    public void MaxInputField()
    {
        int temp = 10000;
        CoinsSelected = temp;
        Game2Manager.instance.inputField.text = temp.ToString();
    }

    public void gold100InputField()
    {
        int temp = 10000;
        CoinsSelected = temp;
        Game2Manager.instance.inputField.text = temp.ToString();
    }

    public void gold200InputField()
    {
        int temp = 20000;
        CoinsSelected = temp;
        Game2Manager.instance.inputField.text = temp.ToString();
    }

    public void gold300InputField()
    {
        int temp = 30000;
        CoinsSelected = temp;
        Game2Manager.instance.inputField.text = temp.ToString();
    }

    public void MinusBet()
    {
        int temp = Convert.ToInt32(Game2Manager.instance.inputField.text);
        temp -= 100;
        if (temp < 100)
        {
            temp = 100;
        }
        CoinsSelected = temp;
        Game2Manager.instance.inputField.text = temp.ToString();
    }

    public void PlusBet()
    {
        int temp = Convert.ToInt32(Game2Manager.instance.inputField.text);

        temp += 100;
        if (temp > 30000)
        {
            temp = 30000;
        }
        CoinsSelected = temp;
        Game2Manager.instance.inputField.text = temp.ToString();
    }

    public void HeadOrTailSelect(int temp)
    {
        userSelected = temp;

        

        if (userSelected == 1)
        {
            HeadTailAnimScript.instance.headTailAnimTxt.text = "Head Selected";
            
        }
        else
        {
            HeadTailAnimScript.instance.headTailAnimTxt.text = "Tail Selected";
        }
        HeadTailAnimScript.instance.PlayHeadTailAnimation();
        ResetGame();
    }
}
