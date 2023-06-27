using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    int rewardcoins,gold;
    public GameObject rewardpanel;
    public AudioSource bttnsound;
    public Text rewardtext;
    void Start()
    {
        if((int)DateTime.Today.DayOfWeek==1&&PlayerPrefs.GetInt("Mon",0)==0)
        {
            rewardpanel.SetActive(true);
            PlayerPrefs.SetInt("Mon", 1);
            PlayerPrefs.SetInt("Sun", 0);
            rewardcoins = 100000;
        }
        if ((int)DateTime.Today.DayOfWeek == 2 && PlayerPrefs.GetInt("Tue", 0) == 0)
        {
            rewardpanel.SetActive(true);
            PlayerPrefs.SetInt("Tue", 1);
            PlayerPrefs.SetInt("Mon", 0);
            rewardcoins = 100000;
        }
        if ((int)DateTime.Today.DayOfWeek == 3 && PlayerPrefs.GetInt("Wed", 0) == 0)
        {
            rewardpanel.SetActive(true);
            PlayerPrefs.SetInt("Wed", 1);
            PlayerPrefs.SetInt("Tue", 0);
            rewardcoins = 150000;
        }
        if ((int)DateTime.Today.DayOfWeek == 4 && PlayerPrefs.GetInt("Thu", 0) == 0)
        {
            rewardpanel.SetActive(true);
            PlayerPrefs.SetInt("Thu", 1);
            PlayerPrefs.SetInt("Wed", 0);
            rewardcoins = 200000;
        }
        if ((int)DateTime.Today.DayOfWeek == 5 && PlayerPrefs.GetInt("Fri", 0) == 0)
        {
            rewardpanel.SetActive(true);
            PlayerPrefs.SetInt("Fri", 1);
            PlayerPrefs.SetInt("Thu", 0);
            rewardcoins = 150000;
        }
        if ((int)DateTime.Today.DayOfWeek == 6 && PlayerPrefs.GetInt("Sat", 0) == 0)
        {
            rewardpanel.SetActive(true);
            PlayerPrefs.SetInt("Sat", 1);
            PlayerPrefs.SetInt("Fri", 0);
            rewardcoins = 100000;
        }
        if ((int)DateTime.Today.DayOfWeek == 7 && PlayerPrefs.GetInt("Sun", 0) == 0)
        {
            rewardpanel.SetActive(true);
            PlayerPrefs.SetInt("Sun", 1);
            PlayerPrefs.SetInt("Sat", 0);
            rewardcoins = 150000;
        }
        gold = PlayerPrefs.GetInt("NewAllGold", 10000000);
        PlayerPrefs.SetInt("NewAllGold", gold + rewardcoins);
        rewardtext.text = rewardcoins + " COINS";
    }
    public void claimbutton()
    {
        rewardpanel.SetActive(false);
        bttnsound.Play();
    }
    //public static DateTime GetNetTime()
    //{
    //    Debug.Log("hoaaaaaaaaaaaaa");
    //    var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
    //    var response = myHttpWebRequest.GetResponse();
    //    string todaysDates = response.Headers["date"];

    //    Debug.Log(DateTime.ParseExact(todaysDates,
    //    "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
    //    CultureInfo.InvariantCulture.DateTimeFormat,
    //    DateTimeStyles.AssumeUniversal)); 

    //    return DateTime.ParseExact(todaysDates,
    //    "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
    //    CultureInfo.InvariantCulture.DateTimeFormat,
    //    DateTimeStyles.AssumeUniversal);
    //}
    //public TimeSpan GetTimeDifference()
    //{
    //    TimeSpan difference = (lastRewardTime - now);
    //    difference = difference.Subtract(debugTime);
    //    return difference.Add(new TimeSpan(0, 24, 0, 0));
    //}
}
