using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Spinner : MonoBehaviour
{
    public static Game4Spinner instance;

    public GameObject[] ImagesHolder1, ImagesHolder2, ImagesHolder3;

    public GameObject handleUp, handleDown;

    public static string num1, num2, num3;

    public static int holder1ImageIndex, holder2ImageIndex, holder3ImageIndex;

    public GameObject game4panel;

    int CoinsSelected;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        CoinsSelected = 100;
    }

    public void LuckySpinner()
    {

        ImagesHolder1[holder1ImageIndex].SetActive(false);
        ImagesHolder2[holder2ImageIndex].SetActive(false);
        ImagesHolder3[holder3ImageIndex].SetActive(false);

        int temp = Convert.ToInt32(Game4Manager.instance.inputField.text);

        if (GameManager.playerGoldInt < 100)
        {
            GameManager.instance.ShopPopUpToggle(true);
            return;
        }

        if (temp < 100 || temp > 30000)
        {
            return;
        }
        CoinsSelected = temp;
        int goldInt = GameManager.playerGoldInt - CoinsSelected;

        if (goldInt < 0)
        {
            goldInt = 0;
        }
        PlayerPrefs.SetInt("NewAllGold", goldInt);
        StartCoroutine(placeHolder1());
        StartCoroutine(placeHolder2());
        StartCoroutine(placeHolder3());
        game4panel.SetActive(false);
    }

    IEnumerator placeHolder1()
    {
        int temp = UnityEngine.Random.Range(0, 7);

        for (int i = 0; i < 40; i++)
        {
            temp = UnityEngine.Random.Range(0, 7);
            ImagesHolder1[temp].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            ImagesHolder1[temp].SetActive(false);
        }
        ImagesHolder1[temp].SetActive(true);
        holder1ImageIndex = temp;
        num1 = ImagesHolder1[temp].name;
    }

    IEnumerator placeHolder2()
    {
        int temp = UnityEngine.Random.Range(0, 7);

        for (int i = 0; i < 40; i++)
        {
            temp = UnityEngine.Random.Range(0, 7);
            ImagesHolder2[temp].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            ImagesHolder2[temp].SetActive(false);
        }
        ImagesHolder2[temp].SetActive(true);
        holder2ImageIndex = temp;
        num2 = ImagesHolder2[temp].name;
    }

    IEnumerator placeHolder3()
    {
        int temp = UnityEngine.Random.Range(0, 7);

        for (int i = 0; i < 40; i++)
        {
            temp = UnityEngine.Random.Range(0, 7);
            ImagesHolder3[temp].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            ImagesHolder3[temp].SetActive(false);
        }
        ImagesHolder3[temp].SetActive(true);
        holder3ImageIndex = temp;
        num3 = ImagesHolder3[temp].name;
        Game4Manager.instance.ShowGoldScrn();
      //  game4panel.SetActive(true);
    }

    public void ResetGame()
    {
        handleUp.SetActive(true);
        handleDown.SetActive(false);
        //ImagesHolder1[holder1ImageIndex].SetActive(false);
        //ImagesHolder2[holder2ImageIndex].SetActive(false);
        //ImagesHolder3[holder3ImageIndex].SetActive(false);
        int temp = 100;
        Game4Manager.instance.inputField.text = temp.ToString();
    }


    public void AutoBet()
    {
        int temp = 200;

        if (GameManager.playerGoldInt < temp)
        {
            GameManager.instance.ShopPopUpToggle(true);
            return;
        }
        Game4Manager.instance.inputField.text = temp.ToString();
        Game4HandleController.instance.CallLuckySpin();
        CoinsSelected = temp;
        PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt - CoinsSelected);
        game4panel.SetActive(false);
    }

    public void MinInputField()
    {
        int temp = 100;
        Game4Manager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void MaxInputField()
    {
        int temp = 30000;
        Game4Manager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void gold100InputField()
    {
        int temp = 10000;
        Game4Manager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void gold200InputField()
    {
        int temp = 20000;
        Game4Manager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void gold300InputField()
    {
        int temp = 30000;
        Game4Manager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void MinusBet()
    {
        int temp = Convert.ToInt32(Game4Manager.instance.inputField.text);
        
        temp -= 100;

        if (temp < 100)
        {
            temp = 100;
        }
        CoinsSelected = temp;
        Game4Manager.instance.inputField.text = temp.ToString();
    }

    public void PlusBet()
    {
        int temp = Convert.ToInt32(Game4Manager.instance.inputField.text);

        temp += 100;

        if (temp > 30000)
        {
            temp = 30000;
        }
        CoinsSelected = temp;
        Game4Manager.instance.inputField.text = temp.ToString();
    }
}
