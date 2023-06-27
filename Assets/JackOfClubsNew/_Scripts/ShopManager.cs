using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public Text coinstext,Gemstext,leveltext;
    public AudioSource Selectsound;
    public GameObject Sounds;
    int coins,gems;
    void Start()
    {
        coins = PlayerPrefs.GetInt("NewAllGold", 100000);
        gems = PlayerPrefs.GetInt("Gems", 0);
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            Sounds.SetActive(false);
        }
        leveltext.text = "LEVEL " + PlayerPrefs.GetInt("Level");
    }
    void Update()
    {
        coinstext.text = "" + coins;
        Gemstext.text = "" + gems;
    }
    public void lastsceneload()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene",0));
    }
    public void Coinpack_1()
    {
        coins += 50000;
        PlayerPrefs.SetInt("NewAllGold", coins);
        Selectsound.Play();
    }
    public void Coinpack_2()
    {
        Selectsound.Play();
        coins += 100000;
        PlayerPrefs.SetInt("NewAllGold", coins);
    }
    public void Coinpack_3()
    {
        Selectsound.Play();
        coins += 200000;
        PlayerPrefs.SetInt("NewAllGold", coins);
    }
    public void Coinpack_4()
    {
        Selectsound.Play();
        coins += 500000;
        PlayerPrefs.SetInt("NewAllGold", coins);
    }
    public void Coinpack_5()
    {
        Selectsound.Play();
        coins += 3000000;
        PlayerPrefs.SetInt("NewAllGold", coins);
    }
    public void Coinpack_6()
    {
        Selectsound.Play();
        coins += 9000000;
        PlayerPrefs.SetInt("NewAllGold", coins);
    }
    public void GemsPack_1()
    {
        Selectsound.Play();
        gems += 50;
        PlayerPrefs.SetInt("Gems", gems);
    }
    public void GemsPack_2()
    {
        Selectsound.Play();
        gems += 200;
        PlayerPrefs.SetInt("Gems", gems);
    }
    public void GemsPack_3()
    {
        Selectsound.Play();
        gems += 1000;
        PlayerPrefs.SetInt("Gems", gems);
    }
}
