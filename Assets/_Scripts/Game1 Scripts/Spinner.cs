using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Spinner : MonoBehaviour
{
    public float reducer;
	public float multiplier = 0;
	bool round1 = true;
	public bool isStoped = false;
    public static string ColorSelected;
    public static int reset = 0;
    public GameObject ColorSelectionPanel,BetSelectionPanel,Colorshowpanel;
    int CoinsSelected;
    public static int spinnerstopped = 0;
    string PreColor = "White";

    private void Start()
    {
        int temp = 1000;
       // GameManager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }
    void FixedUpdate () {

		if (Input.GetKey (KeyCode.Space)) 
		{
			Reset ();
		}

		if (multiplier > 0)
		{
			transform.Rotate (Vector3.forward, 1 * multiplier);
        }
        else
		{
			isStoped = true;
          //  spinnerstopped = 1;
        }
        if(multiplier<0)
        {
            spinnerstopped = 1;
            Debug.Log("hoa");
        }

        if (multiplier < 20 && !round1) 
		{
			multiplier += 0.1f;
		} 
        else 
		{
			round1 = true;
		}

		if (round1 && multiplier > 0)
		{
			multiplier -= reducer;
		}
        if (reset == 1)
        {
            reset = 0;
            BetSelectionPanel.SetActive(true);
        }
	}

    public void ShowSelectedColor(string tempStr)
    {
        ColorSelected = tempStr;
        HeadTailAnimScript.instance.headTailAnimTxt.text = ColorSelected + " Color Selected";
        HeadTailAnimScript.instance.PlayHeadTailAnimation();
        ColorSelectionPanel.SetActive(false);
        BetSelectionPanel.SetActive(true);
        Colorshowpanel.transform.Find(PreColor).gameObject.SetActive(false);
        Colorshowpanel.transform.Find(ColorSelected).gameObject.SetActive(true);
        PreColor = ColorSelected;
    }

	public void Reset()
	{

        int temp = Convert.ToInt32(GameManager.instance.inputField.text);

        if (GameManager.playerGoldInt < 0)
        {
            GameManager.playerGoldInt = 0;
            PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt);
        }

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
        multiplier = 1;
		reducer = UnityEngine.Random.Range (0.01f, 0.5f);
		round1 = false;
		isStoped = false;
        BetSelectionPanel.SetActive(false);
        NeedleCollider.onetime = 0;
        PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt - CoinsSelected);
	}

    public void AutoBet()
    {
        int temp = 200;

        if (GameManager.playerGoldInt < temp)
        {
            GameManager.instance.ShopPopUpToggle(true);
            return;
        }

        GameManager.instance.inputField.text = temp.ToString();
        Reset();
        BetSelectionPanel.SetActive(false);
        CoinsSelected = temp;
        PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt - CoinsSelected);

    }

    public void ResetInputField()
    {
        int temp = 100;
        CoinsSelected = temp;
        GameManager.instance.inputField.text = temp.ToString();
    }

    public void MinInputField()
    {
        int temp = 100;
        GameManager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void MaxInputField()
    {
        int temp = 30000;
        GameManager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;

    }

    public void gold100InputField()
    {
        int temp = 10000;
        GameManager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void gold200InputField()
    {
        int temp = 20000;
        GameManager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void gold300InputField()
    {
        int temp = 30000;
        GameManager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void MinusBet()
    {
        int temp = Convert.ToInt32(GameManager.instance.inputField.text) ;
        temp -= 100;
        if (temp < 100)
        {
            temp = 100;
        }
        GameManager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void PlusBet()
    {
        int temp = Convert.ToInt32(GameManager.instance.inputField.text);

        temp += 100;
        if (temp > 30000)
        {
            temp = 30000;
        }
        GameManager.instance.inputField.text = temp.ToString();
        CoinsSelected = temp;
    }

    public void SpinFunc()
    {
        if(PlayerPrefs.GetInt("sound")==1)
            {
            SoundManager.instance.musicSource.Play();
        }

        Reset();
        
    }
    public void Selectcolor()
    {
        ColorSelectionPanel.SetActive(true);
        BetSelectionPanel.SetActive(false);
    }
}

