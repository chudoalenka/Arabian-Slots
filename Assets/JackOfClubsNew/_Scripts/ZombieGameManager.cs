using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieGameManager : MonoBehaviour
{
    public GameObject coinseffect,MoreCoinseffect, MoreCoinseffect2,Lines, coins, MiniGameBttn,MiniLoading,SlotUnlockPanel;
    public Text amountext, bettext,winamounttext,winamounttext2,leveltext,playersonlinetext, GemsText;
    int betamount,levelno, gems;
    public static int slots;
    public static float winamount, amount;
    public static int win = 0;
    public Image Spinbar,MiniGameBar;
    public SpriteMoving[] sp;
    public int MinBet, minigamescene, thisSceneNo, slotno, BetLimit;
    public AudioSource bttnsound, Spinsound,winsound,slotunlock,losesound;
    public Button[] betbttns;
    float levelbarvalue;
    public static float miniloadvalue=0;


    public GameObject rewardpanel,Adbttn,Kingkongminipanel;

    public int noofspin = 0;
    public int nextlevelunlockvalue;
    public GameObject[] kingkongmini;
    public GameObject kingkongbig;
    public AudioSource[] kingkongminiaudios;
    public static int kingkong = 0;
    public static int king10,king15;
    int kingonetime = 0;
    int freespins = 0;
    public Text freespingstext;
    public int testvalue;
    public static int autorotate=0;
    #region startF
    void Start()
    {
        autorotate = 0;
        testvalue = PlayerPrefs.GetInt("noofgames");
        slots = slotno;

        levelbarvalue = PlayerPrefs.GetFloat("LevelBar" + thisSceneNo, 0f);
        levelno = PlayerPrefs.GetInt("Level" + thisSceneNo, 1);

        Spinbar.fillAmount = levelbarvalue;
        betamount = MinBet;
        amount = PlayerPrefs.GetInt("NewAllGold",500000);

        leveltext.text = "LEVEL " + PlayerPrefs.GetInt("Level",1);
        //playersonlinetext.text = Random.Range(30, 80) + "";

        gems = PlayerPrefs.GetInt("Gems", 0);
        GemsText.text = "" + gems;
        MiniGameBar.fillAmount += miniloadvalue;


    }
    #endregion
    void Update()
    {
        if (amount < betamount)
        {
            betbttns[3].interactable = false;
        }
        bettext.text = "" + betamount;
        amountext.text =  amount.ToString("0");
        PlayerPrefs.SetInt("NewAllGold", (int)amount);
       
        if (amount < 0) { amount = 0; }
        if (sp[0].istopped&& sp[1].istopped && sp[2].istopped && sp[3].istopped && sp[4].istopped)
        {
            sp[0].istopped = false;
            Invoke("Active", 0.2f);           
            Spinbar.fillAmount += 0.01f;
            miniloadvalue += 0.05f;
            MiniGameBar.fillAmount += 0.05f;
            PlayerPrefs.SetFloat("LevelBar" + thisSceneNo, Spinbar.fillAmount);

            if (MiniGameBar.fillAmount>0.96&&thisSceneNo!=11 && thisSceneNo != 13 && thisSceneNo != 14 && thisSceneNo != 16)
            {             
                 StartCoroutine("MiniGameLaunch");                             
            }
            if (Spinbar.fillAmount>0.95&Spinbar.fillAmount<1)
            {
                Spinbar.fillAmount = 0f;
                Time.timeScale = 1f;
                levelno++;
                PlayerPrefs.SetFloat("LevelBar" + thisSceneNo, 0);
            }
            sp[0].istopped = false;
            Time.timeScale = 0.95f;
           
        }
        if (win == 1)
        {
            //  winamount = Random.Range(5, 8);
           
            amount += (betamount * (winamount))+betamount;
            CoinsSpwan();
            Invoke("CancelInvokes", 4);
            Invoke("MoreCoins", 0.5f);
            win = 0;
        }
        if (kingkong == 1&&kingonetime==0)
        {
            kingonetime++;
            //  kingkongbig.SetActive(true);
            StartCoroutine("MiniGameLaunch");
            //Invoke("MiniGameLaunch", 3f);
            kingkong = 0;
        }
    }
    public void Spin()
    {       
            noofspin++;
            Spinsound.Play();
            bttnsound.Play();
            if (freespins < 1)
            {
                amount -= betamount;
                freespingstext.text = "";
            }
            else { AutoSpin(); }
            CancelInvoke();
            winamounttext.text = "";
            betbttns[0].interactable = false;
            betbttns[1].interactable = false;
            betbttns[2].interactable = false;
            betbttns[3].interactable = false;
            PlayerPrefs.SetInt("noofgames", PlayerPrefs.GetInt("noofgames", 0) + 1);
            kingonetime = 0;       
    }
    public void AutoSpin()
    {
        freespins--; freespingstext.text = "" + freespins;
    }
    public void Add()
    {
        bttnsound.Play();

        if (betamount < BetLimit && amount>betamount*2)
        {
            betamount *= 2;
        }
    }
    public void MaxBet()
    {
        bttnsound.Play();

        if (amount > BetLimit)
        {
            betamount = BetLimit;
        }
    }
    public void Minus()
    {
        bttnsound.Play();
        betbttns[3].interactable = true;
        if (betamount >MinBet)
        {
            betamount/=2;
        }
    }
    void Active()
    {
        winamount = 0;
        winamounttext2.text =0+"";
        Lines.SetActive(true);
        Invoke("ActiveButtons", 0.2f);
        if (PlayerPrefs.GetInt("noofgames") == nextlevelunlockvalue)
        {
            slotunlock.Play();
            SlotUnlockPanel.SetActive(true);
            StartCoroutine("unlockpanelfalse");
        }
    }
    IEnumerator unlockpanelfalse()
    {
        yield return new WaitForSeconds(4f);
        SlotUnlockPanel.SetActive(false);
    }
    void ActiveButtons()
    {
        if (winamount < 1&&freespins<1)
        {
          //  losesound.Play();
            betbttns[0].interactable = true;
            betbttns[1].interactable = true;
            betbttns[2].interactable = true;
            betbttns[3].interactable = true;
        }
        if (freespins > 0)
        {
            Invoke("Spin",1);
            
            autorotate = 1;
        }
    }
    public void CoinsSpwan()
    {
        winsound.Play();
        winamounttext.GetComponent<Animator>().enabled = true;
        float amountwon = (betamount *(winamount))+betamount;
        if (amountwon > 0)
        {
            winamounttext.text = amountwon.ToString("0") + "\n Win";
            winamounttext2.text = amountwon.ToString("0") + "\n Win";
        }
        Invoke("CoinsSpwan", 0.1f);      
    }
    public void CancelInvokes()
    {
        winamounttext.GetComponent<Animator>().enabled = false;
        winamounttext.text = "";
        CancelInvoke();
        coinseffect.SetActive(false);
        if (freespins < 1)
        {
            betbttns[0].interactable = true;
            betbttns[1].interactable = true;
            betbttns[2].interactable = true;
            betbttns[3].interactable = true;
        }
    }
    void MoreCoins()
    {
        MoreCoinseffect.SetActive(false);
        MoreCoinseffect.SetActive(true);
        Invoke("MoreCoins2", 1f);       
    }
    void MoreCoins2()
    {
        MoreCoinseffect2.SetActive(false);
        MoreCoinseffect2.SetActive(true);
    }
    IEnumerator MiniGameLaunch()
    {
        yield return new WaitForSeconds(2f);
        if (thisSceneNo == 13)
        {
            yield return new WaitForSeconds(2f);
            if (freespins < 1)
            {
                Kingkongminipanel.SetActive(true);               
                
                StartCoroutine("kingkonghide");             
            }
            if (king10 == 1)
            {
                kingkongmini[0].SetActive(true);
                kingkongminiaudios[0].Play();
                freespins = 10;
                king10 = 0;
            }
            if (king15 == 1)
            {
                kingkongmini[1].SetActive(true);
                kingkongminiaudios[1].Play();
                freespins = 15;
                king15 = 0;
            }
             freespingstext.text = "" + freespins;
        }
        else if (thisSceneNo == 16)
        {
            yield return new WaitForSeconds(2f);
            //  Kingkongminipanel.SetActive(true);
            if (king10 == 1)
            {
                freespins = 15;
                king10 = 0;
            }
            if (king15 == 1)
            {
                freespins = 20;
                king15 = 0;
            }
            freespingstext.text = "" + freespins;
            StartCoroutine("kingkonghide");
        }
        else
        {
            MiniLoading.SetActive(true);
            SceneManager.LoadScene(minigamescene);
        }
    }
  IEnumerator kingkonghide()
    {
        yield return new WaitForSeconds(2.5f);
        Kingkongminipanel.SetActive(false);
        kingkongmini[0].SetActive(false); kingkongmini[1].SetActive(false); kingkongmini[2].SetActive(false);      
    }

   
   
    public void rewardpanelOff()
    {
        rewardpanel.SetActive(false);
    }
}
