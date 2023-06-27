using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game3PointerCollider : MonoBehaviour
{
    public Game3Spinner _spinner;
    public TextMeshProUGUI scoretext;
    public int tempScoreCount;

    void OnTriggerStay2D(Collider2D col)
    {
        //if (!_spinner.isStoped)
        //    return;

        tempScoreCount = Convert.ToInt32(Game3Manager.instance.inputField.text);

        int tempVar = Convert.ToInt32(Game3Manager.instance.playerCollectedGold.text);

        tempScoreCount = tempScoreCount * tempVar;

        scoretext.text = tempScoreCount.ToString();

        Game3Manager.instance.playerCollectedGold.text = tempScoreCount.ToString();

        Game3Manager.instance.goldScrn.SetActive(true);

        GameManager.instance.CongratsEffectToggle();


    }
}
