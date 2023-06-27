using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyminidetect : MonoBehaviour
{
    public Detector[] Ds;
    public GameObject[] animated,animated2;
    public GameObject minipanel; 
    int streak,streak2;
    public AudioSource freespinsound1, freespinsound2, freespinsound3;
    //void Start()
    //{
    //    streak = 0;
    //    Invoke("checkstreak", 1f);
        
    //}
    private void OnEnable()
    {
        streak = 0;
        streak2 = 0;
        for (int i = 0; i < 15; i++)
        {
            animated[i].SetActive(false);
            animated2[i].SetActive(false);
        }
        Invoke("checkstreak", 1f);
        Invoke("checkstreak2", 1f);
        ZombieGameManager.king10 = 0;
        ZombieGameManager.king15 = 0;
    }
   
    void checkstreak()
    {
        for(int i = 0; i < 15; i++)
        {
            if (Ds[i].BlockName == "monkeymini")
            {
                streak++;
                animated[i].SetActive(true);
                Debug.Log("streak " + streak);
            }
        }
        if (streak < 3)
        {
            for (int i = 0; i < 15; i++)
            {
                animated[i].SetActive(false);
                animated2[i].SetActive(false);
            }
            streak = 0;
            return;
        }
        if (streak == 3)
        {
            minipanel.SetActive(true);
            minipanel.transform.GetChild(0).transform.gameObject.SetActive(true);
            freespinsound1.Play();
            ZombieGameManager.kingkong = 1;
            ZombieGameManager.king10 = 1;
        }
        if (streak == 4)
        {
            minipanel.SetActive(true);
            minipanel.transform.GetChild(1).transform.gameObject.SetActive(true);
            freespinsound2.Play();
            ZombieGameManager.kingkong = 1;
            ZombieGameManager.king15 = 1;
        }
        if (streak >= 5)
        {
            minipanel.SetActive(true);
            minipanel.transform.GetChild(2).transform.gameObject.SetActive(true);
            freespinsound3.Play();
            ZombieGameManager.kingkong = 1;
            ZombieGameManager.king15 = 1;
        }
        streak = 0;
    }
    void checkstreak2()
    {
        for (int i = 0; i < 15; i++)
        {
            if (Ds[i].BlockName == "monkeymini2")
            {
                streak2++;
                animated2[i].SetActive(true);
                Debug.Log("streak2 " + streak2);
            }
        }
        if (streak2 < 3)
        {
            for (int i = 0; i < 15; i++)
            {
                animated2[i].SetActive(false);
            }
            streak2 = 0;
            return;
        }
        if (streak2 == 3)
        {
            minipanel.SetActive(true);
            minipanel.transform.GetChild(1).transform.gameObject.SetActive(true);
            freespinsound2.Play();
            ZombieGameManager.kingkong = 1;
            ZombieGameManager.king15 = 1;
        }
        if (streak2 == 4)
        {
            minipanel.SetActive(true);
            minipanel.transform.GetChild(2).transform.gameObject.SetActive(true);
            freespinsound3.Play();
            ZombieGameManager.kingkong = 1;
            ZombieGameManager.king15 = 1;
        }
        if (streak2 >= 5)
        {
            minipanel.SetActive(true);
            minipanel.transform.GetChild(2).transform.gameObject.SetActive(true);
            freespinsound3.Play();
            ZombieGameManager.kingkong = 1;
            ZombieGameManager.king15 = 1;
        }
        streak = 0;
    }
}
