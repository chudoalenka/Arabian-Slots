using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NeedleCollider : MonoBehaviour
{
    public Spinner _spinner;
    public TextMeshProUGUI scoretext;
    public int tempScoreCount;
    public TextMeshProUGUI playerCollectedGold;
    public static int onetime = 0;
    public Collider2D cd;
 
    void Start()
    {
        //int temp = Convert.ToInt32(playerCollectedGold.text);
        //temp += SaveSystem.instance.GetScorePlayerPrefs();
        //playerCollectedGold.text = temp.ToString();
        cd.enabled = false;
    }
    private void Update()
    {
        playerCollectedGold.text = GameManager.playerGoldInt.ToString();
        if(Spinner.spinnerstopped==1)
        {
            Spinner.spinnerstopped = 0;
            cd.enabled = true;
        }

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (!_spinner.isStoped)
            return;
        if (PlayerPrefs.GetInt("sound") == 1)
        {

        SoundManager.instance.musicSource.Stop(); }

        scoretext.text = col.gameObject.name;

        if (Spinner.ColorSelected == "Red" && scoretext.text == "10")
        {

        }
        else if (Spinner.ColorSelected == "Orange" && (scoretext.text == "20" || scoretext.text == "0"))
        {

        }
        else if (Spinner.ColorSelected == "White" && scoretext.text == "3")
        {

        }
        else if (Spinner.ColorSelected == "Blue" && scoretext.text == "8")
        {

        }
        else if (Spinner.ColorSelected == "Purple" && scoretext.text == "9")
        {

        }
        else if (Spinner.ColorSelected == "Green" && (scoretext.text == "7" || scoretext.text == "5"))
        {

        }
        else
        {
            GameManager.instance.LoseScrn.SetActive(true);
            return;
        }

        tempScoreCount = Convert.ToInt32(scoretext.text);

        int tempVar = Convert.ToInt32(GameManager.instance.inputField.text);

        tempScoreCount = tempScoreCount * tempVar;

        scoretext.text = tempScoreCount.ToString();

        //tempVar = Convert.ToInt32(playerCollectedGold.text);

        //tempScoreCount = tempScoreCount + tempVar;

        //if (tempScoreCount > 99999999)
        //{
        //    tempScoreCount = 99999999;
        //}
        if (onetime == 0)
        {

            GameManager.playerGoldInt += tempScoreCount;

            if (GameManager.playerGoldInt < 0)
            {
                GameManager.playerGoldInt = 0;
            }
            onetime++;
            playerCollectedGold.text = GameManager.playerGoldInt.ToString();

            PlayerPrefs.SetInt("NewAllGold", GameManager.playerGoldInt);
        }

        GameManager.instance.goldScrn.SetActive(true);

        GameManager.instance.CongratsEffectToggle();
    }

}
