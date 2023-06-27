using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pinatascript : MonoBehaviour
{
    public GameObject  rope, Effects, Effects1, Effects2, GemsEffect, bttn,Sounds;
    public GameObject[] Pinatas;
    public Text coinstext,SpinsText, GemsText, Winamounttext, leveltext;
    int coins = 0;
    int spins;
    int r, gems;
    public AudioSource winningsound;
     void Start()
    {
        spins = Random.Range(3, 7);
        SpinsText.text = "" + spins;
        r = Random.Range(0, 4);
        Pinatas[r].SetActive(true);
      //  gems = PlayerPrefs.GetInt("Gems", 0);
        GemsText.text = "" + gems;
        ZombieGameManager.miniloadvalue = 0;
        leveltext.text = "LEVEL " + PlayerPrefs.GetInt("Level");
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            Sounds.SetActive(false);
        }
    }
    IEnumerator coinscounting()
    {
        if (coins < 10000)
        {
            //coins += 100;
        }
        else
        {
           // coinstext.GetComponent<Animator>().SetBool("large", true);
        }
        coinstext.text = "" + coins;
        yield return new WaitForSeconds(0f);
        StartCoroutine(coinscounting());
    }
    public void Tap()
    {
        int[] RandomAmount = new int[] { 500, 1000, 2000, 5000,500,1000,2000,5000,1000,10000,20000,2000,1000,15000 };
        int ran = RandomAmount[Random.Range(0, RandomAmount.Length)];
        coins += ran;
        Winamounttext.text = "Win \n" + ran;
        spins--;
        SpinsText.text = "" + spins;
        bttn.SetActive(false);
        Pinatas[r].SetActive(false);
        rope.SetActive(false);
        Effects.SetActive(true);
        StartCoroutine(coinscounting());
        Invoke("MoreCoins1",0.5f);
        winningsound.Play();
    }
    void MoreCoins1()
    {
        Effects1.SetActive(false);
        Effects1.SetActive(true);
        Invoke("MoreCoins2", 1f);
    }
    void MoreCoins2()
    {
        Effects2.SetActive(false);
        Effects2.SetActive(true);
        GemsEffect.SetActive(false);
        GemsEffect.SetActive(true);
        gems += Random.Range(2, 5);
        GemsText.text = "" + gems;
        Invoke("again", 2f);
    }
    public void again()
    {
        if (spins > 0)
        {
            bttn.SetActive(true);
            r++;
            if (r == 4){ r = 0; }
            Pinatas[r].SetActive(true);
            rope.SetActive(true);
            Effects.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("NewAllGold", PlayerPrefs.GetInt("NewAllGold") + coins);
            PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") + gems);
            SceneManager.LoadScene(0);
        }
        StopAllCoroutines();
        CancelInvoke();
    }
}
