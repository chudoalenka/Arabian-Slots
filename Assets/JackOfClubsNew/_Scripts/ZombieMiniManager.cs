using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieMiniManager : MonoBehaviour
{
    public static int RandomValue;
    public GameObject bttns,lines,Effects, MoreCoinseffect, MoreCoinseffect2,GemsEffect,PopUp, UperPanel,bareffect;
    public GameObject[] NeonImages;
    public Transform[] rows; 
    public Detector D;
    public Image bar;
    public int coins,freespins,scenename;
    public Text coinstext,spinstext,Winamounttext,GemsText, leveltext;
    public SpriteMovingMini[] sp;
    public AudioSource spinsound,Winsound;
    public Detector[] detector;
    int i = 0; int gems = 0;
    int d1, d2, d3;
    public int backscene;

     void Start()
    {
        coins = 0;
        RandomValue = Random.Range(60, 80);
        Time.timeScale = 1;
        freespins = Random.Range(3,7);
        spinstext.text = "" + freespins;
       // gems = PlayerPrefs.GetInt("Gems", 0);
        GemsText.text = "" + gems;
        ZombieGameManager.miniloadvalue = 0;
        leveltext.text = "LEVEL " + PlayerPrefs.GetInt("Level",1);
        //if (PlayerPrefs.GetInt("sound") == 0)
        //{
        //    Sounds.SetActive(false);
        //}
    }
    void Update()
    {
      
        if (sp[0].IsStopped && sp[1].IsStopped && sp[2].IsStopped)
        {
            RandomValue = Random.Range(60, 80);
            sp[0].IsStopped = false;
            lines.SetActive(true);
            Invoke("PatternCheck", 0.5f);
            Time.timeScale = 1;
            StartCoroutine(barfilling());
        }
    }
    IEnumerator barfilling()
    {
        bar.fillAmount += 0.025f;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(barfilling());
    }
        void NeonActive()
    {
        if (backscene == 2)
        {
            NeonImages[i].SetActive(false);
            i++;
            if (i == 5) { i = 0; }
            NeonImages[i].SetActive(true);
            Invoke("NeonActive", 0.1f);
        }
    }
    IEnumerator coinscounting()
    {
        if (coins < 10000)
        {
          // coins += 100;
        }
        else
        {
            //coinstext.GetComponent<Animator>().SetBool("large", true);
        }
        coinstext.text = "" + coins;
        yield return new WaitForSeconds(0f);
        StartCoroutine(coinscounting());
    }
    public void spin()
    {
        freespins--;
        bttns.SetActive(false);
        lines.SetActive(false);
        NeonActive();
        spinstext.text = "" + freespins;
        spinsound.Play();
    }
    public void PatternCheck()
    {
        //PopUp.SetActive(true);
        bareffect.SetActive(true);
        if (scenename == 10 || scenename == 9)
        {
            d1 = int.Parse(detector[0].BlockName);
            d2 = int.Parse(detector[1].BlockName);
            d3 = int.Parse(detector[2].BlockName);
            int winamount= (d1 * 1000) + (d2 * 1000) + (d3 * 1000);
            coins += winamount;
            Winamounttext.text = "Win \n" + winamount;
        }
        else {

            int[] RandomAmount = new int[] { 500, 1000, 2000, 5000, 500, 1000, 2000, 5000, 1000, 10000,
                20000, 2000, 1000, 15000 };
            int r= RandomAmount[Random.Range(0, RandomAmount.Length)];
            coins += r;
            Winamounttext.text = "Win \n" + r;
        }
        if (coins > 0)
        {
            Invoke("MoreCoins1", 0.5f);
            Effects.SetActive(true);
        }
       
        ZombieGameManager.amount += coins;
       // UperPanel.SetActive(false);
        StartCoroutine(coinscounting());
        Winsound.Play();

        CancelInvoke("NeonActive");
        if (backscene == 2)
        {
            NeonImages[i].SetActive(false);
            int n = int.Parse(D.BlockName);
            if (n == 5) { n = 0; }
            NeonImages[n].SetActive(true);
        }
     
    }
    public void PanelOff()
    {
        bareffect.SetActive(false);

        MoreCoinseffect2.SetActive(false);
        GemsEffect.SetActive(false);
        CancelInvoke();
        PopUp.SetActive(false);
        Winamounttext.text = "";
        if (freespins > 0)
        {
            bttns.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("NewAllGold", PlayerPrefs.GetInt("NewAllGold") + coins);
            PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") + gems);
            SceneManager.LoadScene(backscene);
        }
    }
    void MoreCoins1()
    {
        MoreCoinseffect.SetActive(false);
        MoreCoinseffect.SetActive(true);
        Invoke("MoreCoins2", 1f);
    }
    void MoreCoins2()
    {
        MoreCoinseffect2.SetActive(false);
        MoreCoinseffect2.SetActive(true);
        GemsEffect.SetActive(true);
        gems+= Random.Range(2, 5);
        
        GemsText.text = "" + gems;
       
        if (freespins > 0)
        {
            bar.fillAmount = 0;
            coinstext.text = "";
            Effects.SetActive(false);
            MoreCoinseffect.SetActive(false);
        }
      
        Invoke("PanelOff", 2f);
    }
}
