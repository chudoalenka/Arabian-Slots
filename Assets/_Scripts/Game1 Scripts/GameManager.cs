using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_InputField inputField;
    public GameObject goldScrn, LoseScrn, Game4Panel,Menu,dicesbttn,slotbttns,CoinsGameBttns,
        gameselectScrn, shopPopUp, PiratesComingSoon;
    public GameObject[] Games, congratsEffect;
    public static int playerGoldInt;
    public TextMeshProUGUI TotalCoinstext;
    public Text[] leveltext;
    public Image[] levelbarImage;
    int Game1Level, Game2Level, Game3Level, Game4Level;
    float[] barvalues;
    int[] GamesLevel;
    int soundvalue;
    public Text[] PlayersOnlinetext;
    public Text[] GemsText;
    int gems;
    int playeronline;
    public static int gameopen=0;
    public GameObject rewardpanel;

    void Start()
    {
       

        if (gameopen == 0)
        {
            gameselectScrn.SetActive(true);
        }
        else
        {
            gameselectScrn.SetActive(false);
            Games[gameopen - 1].SetActive(true);
        }
        gems = PlayerPrefs.GetInt("Gems", 0);
        for(int i = 0; i < 4; i++)
        {
            GemsText[i].text = "" + gems;
        }
        GamesLevel = new int[5];
        barvalues = new float[5];
        PlayerPrefs.SetInt("LastScene", 1);
        if (instance == null)
        {
            instance = this;
        }
        levelsystem();
        PlayerPrefs.SetInt("ShowShop", 0);

        inputField.text = 100 + "";

        if (PlayerPrefs.GetInt("FirstTimePlaying") != 1)
        {
            PlayerPrefs.SetInt("FirstTimePlaying", 1);
         //   PlayerPrefs.SetInt("NewAllGold", 500000);
        }
        playerGoldInt = PlayerPrefs.GetInt("NewAllGold", 50000);

        //if (soundvalue == PlayerPrefs.GetInt("sound", 1))
        //{
        //    if(soundvalue==0)
        //    {
        //        Sounds.SetActive(false);
        //    }
        //    if (soundvalue == 1)
        //    {
        //        Sounds.SetActive(true);
        //    }
        //}
        playeronline = Random.Range(10,500);
        for (int i = 0; i < 4; i++) {
            PlayersOnlinetext[i].text = "" + playeronline; }
    }
    private void Update()
    {
        playerGoldInt = PlayerPrefs.GetInt("NewAllGold", 50000);       
    }
    public void levelsystem()
    {
        for(int i = 0; i < 4; i++)
        {
            barvalues[i]= PlayerPrefs.GetFloat("Game"+i+1+"Bar", 0f);
          //  GamesLevel[i] = PlayerPrefs.GetInt("Game" + i+1 + "Level", 1);
            //levelbarImage[i].fillAmount = barvalues[i];
            leveltext[i].text = "LEVEL " + GamesLevel[i];
        }
    }
    public void Game1Spin()
    {
       // levelbarImage[0].fillAmount += 0.1f;
     //   PlayerPrefs.SetFloat("Game" + 1 + "Bar", levelbarImage[0].fillAmount);
        //if (levelbarImage[0].fillAmount == 1)
        //{
        //    levelbarImage[0].fillAmount = 0;
        //    GamesLevel[1]++;
        //    PlayerPrefs.SetInt("Game" +1 + "Level", GamesLevel[1]);
        //    PlayerPrefs.SetFloat("Game" + 1 + "Bar", 0f);
        //    leveltext[0].text = "LEVEL " + GamesLevel[1];
        //}
    }
    public void Game2Spin()
    {
       // levelbarImage[1].fillAmount += 0.1f;
      //  PlayerPrefs.SetFloat("Game" + 1 + "Bar", levelbarImage[0].fillAmount);

        //if (levelbarImage[1].fillAmount == 1)
        //{
        //    levelbarImage[1].fillAmount = 0;
        //    GamesLevel[2]++;
        //    PlayerPrefs.SetInt("Game" + 2 + "Level", GamesLevel[2]);
        //    PlayerPrefs.SetFloat("Game" + 2 + "Bar", 0f);
        //    leveltext[1].text = "LEVEL " + GamesLevel[2];
        //}
    }
    public void Game3Spin()
    {
        levelbarImage[2].fillAmount += 0.1f;
        PlayerPrefs.SetFloat("Game" + 1 + "Bar", levelbarImage[0].fillAmount);

        if (levelbarImage[2].fillAmount == 1)
        {
            levelbarImage[2].fillAmount = 0;
            GamesLevel[3]++;
            PlayerPrefs.SetInt("Game" + 3 + "Level", GamesLevel[3]);
            PlayerPrefs.SetFloat("Game" + 3 + "Bar", 0f);
            leveltext[2].text = "LEVEL " + GamesLevel[3];
        }
    }
    public void Game4Spin()
    {
        //levelbarImage[3].fillAmount += 0.1f;
        //PlayerPrefs.SetFloat("Game" + 1 + "Bar", levelbarImage[0].fillAmount);

        //if (levelbarImage[3].fillAmount == 1)
        //{
        //    levelbarImage[3].fillAmount = 0;
        //    GamesLevel[4]++;
        //    PlayerPrefs.SetInt("Game" + 4 + "Level", GamesLevel[4]);
        //    PlayerPrefs.SetFloat("Game" + 4 + "Bar", 0f);
        //    leveltext[3].text = "LEVEL " + GamesLevel[4];
        //}
    }

    public void goldScrnToggle()
    {
        goldScrn.SetActive(false);
        LoseScrn.SetActive(false);
        Spinner.reset = 1;
        dicesbttn.SetActive(true);
        slotbttns.SetActive(true);
        CoinsGameBttns.SetActive(true);
    }

    public void SelectGame(int check)
    {
        gameselectScrn.SetActive(false);
        Games[check].SetActive(true);
        gameopen = check+1;
        Menu.SetActive(false);
    }

    public void CongratsEffectToggle()
    {
        for (int i = 0; i < 4; i++)
        {
            congratsEffect[i].SetActive(true);
        }
            
        StartCoroutine(ToggleCongratsEffect());
    }
    private IEnumerator ToggleCongratsEffect()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 4; i++)
        {
            congratsEffect[i].SetActive(false);
        }
    }
    public void SoundCaller(int check)
    {
        if (check == 1)
        {
            SoundManager.instance.PlaySound();
        }
        else if (check == 2)
        {
            SoundManager.instance.MuteSound();
        }      
    }
    public void ShopPopUpToggle(bool check)
    {
        if(check)
            shopPopUp.SetActive(true);
        else
            shopPopUp.SetActive(false);
    }
    public void GotoShop()
    {
        PlayerPrefs.SetInt("ShowShop", 1);
        LevelLoader.instance.LoadLevel(0);
    }
    public void newleve(int l)
    {
        if (l == 0||l==1) { gameopen = 0; }
        SceneManager.LoadScene(l);
    }
    public void Pirates_ComingSoon(bool value)
    {
        PiratesComingSoon.SetActive(value);
    }
   
  
    public void rewardpanelOff()
    {
        rewardpanel.SetActive(false);
    }

}
