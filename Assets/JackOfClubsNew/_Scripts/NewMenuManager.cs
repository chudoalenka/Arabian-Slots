using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject Splash,SlotMenu,loadingscreen,PiratesComingSoon,LoginPanel,
        MainCanvas,VideoObj,SettingsPanel,HowToPanel,AboutUsPanel,ComingSoonPanel,Coingame,Dicegame,Slotgame,Wheelgame;
    public AudioSource bttnsound,Backsound,welcomesound,welcomeagainsound;
    int gold;
    public static int firsttime = 0;
    public static int fromslot = 0;
    public Button[] SlotButtons;
    public GameObject[] Locks;
    public GameObject fbbttn;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Login", 0) == 1)
        {
            LoginPanel.SetActive(false);
            
        }
        else
        {
            Invoke("welcome", 8f);
        }
        ZombieGameManager.miniloadvalue = 0;
        gold = PlayerPrefs.GetInt("NewAllGold", 10000000);
        PlayerPrefs.SetInt("NewAllGold", gold);
        StartCoroutine(waiting());
        PlayerPrefs.SetInt("LastScene", 0);
        Splash.SetActive(false);
        if (firsttime == 0)
        {
            firsttime = 1;
            MainCanvas.SetActive(false);
            Invoke("canvasactive", 5f);
            Invoke("BackSoundActive", 7f);
            if (PlayerPrefs.GetInt("Login", 0) == 1)
            {
                Invoke("welcomeagain", 8f);
            }
        }
        else
        {
            Backsound.Play();
            VideoObj.SetActive(false);
        }
        if (fromslot == 0)
        {
            SlotMenu.SetActive(false);
        }
        else
        {
            SlotMenu.SetActive(true);
        }
        PlayerPrefs.SetInt("Level", 1);
        if (PlayerPrefs.GetInt("noofgames", 0) > 49)
        {
            SlotButtons[0].interactable = true;
            Locks[0].SetActive(false);
            PlayerPrefs.SetInt("Level", 2);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 99)
        {
            SlotButtons[1].interactable = true;
            Locks[1].SetActive(false);
            PlayerPrefs.SetInt("Level", 3);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 199)
        {
            SlotButtons[2].interactable = true;
            Locks[2].SetActive(false);
            PlayerPrefs.SetInt("Level", 4);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 249)
        {
            SlotButtons[3].interactable = true;
            Locks[3].SetActive(false);
            PlayerPrefs.SetInt("Level", 5);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 299)
        {
            SlotButtons[4].interactable = true;
            Locks[4].SetActive(false);
            PlayerPrefs.SetInt("Level", 6);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 349)
        {
            SlotButtons[5].interactable = true;
            Locks[5].SetActive(false);
            PlayerPrefs.SetInt("Level", 7);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 399)
        {
            SlotButtons[6].interactable = true;
            Locks[6].SetActive(false);
            PlayerPrefs.SetInt("Level", 8);
        }

    }
    void welcome()
    {
        welcomesound.Play();
    }
    void welcomeagain()
    {
        welcomeagainsound.Play();
    }

    void BackSoundActive()
    {
        Backsound.Play();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator waiting()
    {
        yield return new WaitForSeconds(3);
        Splash.SetActive(false);
       
    }
    public void SplashActive()
    {
        StartCoroutine(waiting2());       
    }
    IEnumerator waiting2()
    {
        yield return new WaitForSeconds(0.3f);
        Splash.SetActive(true);
    }
    public void SlotActivve(bool value)
    {
        fromslot = 0;
        bttnsound.Play();
        SlotMenu.SetActive(value);
    }
    public void loading()
    {
        loadingscreen.SetActive(true);
    }
    public void Pirates_ComingSoon(bool value)
    {
        PiratesComingSoon.SetActive(value);
    }
    public void canvasactive()
    {
        StartCoroutine(waiting());
        Splash.SetActive(true);
        MainCanvas.SetActive(true);
    }
    public void SettingsONOFF(bool value)
    {
        bttnsound.Play();
        SettingsPanel.SetActive(value);
    }
    public void HowToOnOFF(bool value)
    {
        bttnsound.Play();
        HowToPanel.SetActive(value);
    }
    public void CoingameONOFF(bool value)
    {
        bttnsound.Play();
        Coingame.SetActive(value);
    }
    public void DiceGameONOFF(bool value)
    {
        bttnsound.Play();
        Dicegame.SetActive(value);
    }
    public void SlotgameONOFF(bool value)
    {
        bttnsound.Play();
        Slotgame.SetActive(value);
    }
    public void WheelONOFF(bool value)
    {
        bttnsound.Play();
        Wheelgame.SetActive(value);
    }
    public void AboutUsOnOff(bool value)
    {
        bttnsound.Play();
        AboutUsPanel.SetActive(value);
    }
    public void ComingSoonOnOff(bool value)
    {
        bttnsound.Play();
        ComingSoonPanel.SetActive(value);
    }
    public void loginfalse()
    {
        LoginPanel.SetActive(false);
        PlayerPrefs.SetInt("Login", 1);
    //    fbbttn.SetActive(false);

    }
}
