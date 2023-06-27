using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningLine : MonoBehaviour
{
    public Detector[] Ds;
    public SpriteRenderer sp;
    public bool win;
    public GameObject Effect;
    public int streak, onetime;
    Animator lineanim;
    public string animationname;
    bool withwild;
    string Priority,IconName;
    float wildpoints;
    public GameObject kingkong;
    public AudioSource minigamesound;
    private void Start()
    {
        wildpoints = 0;
        withwild = false;
        onetime = 0; streak = 1;
        lineanim = this.GetComponent<Animator>();
        ZombieGameManager.winamount = 0.8f;
       
    }
    private void OnEnable()
    {
        win = false;
        onetime = 0;
        streak = 1;
        sp.enabled = false;
        ZombieGameManager.king10 = 0;
        ZombieGameManager.king15 = 0;
    }
    private void Update()
    {
        if (onetime == 0)
        {
            Invoke("checkresult", 0.5f);
            onetime = 1;
        }
    }
    void checkresult()
    {
        for (int i = 0; i < 1; i++)
        {
            int onetime = 0;
            for (int j = i + 1; j < ZombieGameManager.slots; j++)
            {
                if(Ds[0].BlockName=="wild"&&onetime==0)
                {
                    withwild = true;
                    wildpoints = 0.5f;
                    streak++;
                    onetime++;
                    i = 1; j = 2;
                }
                if ((Ds[2].BlockName == "wild" && onetime == 0&&streak==1)|| 
                    (Ds[3].BlockName == "wild" && onetime == 0 && streak == 2)||
                    (Ds[4].BlockName == "wild" && onetime == 0 && streak == 3))
                {
                    withwild = true;
                    streak++;
                    onetime++;
                    wildpoints = 0.5f;
                }
                if (Ds[i].BlockName == Ds[j].BlockName && Ds[j].BlockName != "NoPoints")
                {
                    streak++;                  
                    IconName = Ds[i].BlockName;
                    if (IconName == "hand" || IconName == "rip" || IconName == "acid" || IconName == "bats" || 
                        IconName == "guitar" || IconName == "2" || IconName == "3" || IconName == "5"
                        || IconName == "8" || IconName == "9" || IconName == "11" || IconName == "12")
                    {
                        Priority = "Low";
                    }
                    else if (IconName =="zombie1" || IconName == "zombie2" || IconName == "zombie3"||
                        IconName == "1" || IconName == "4" || IconName == "10" || IconName == "13")
                    {
                        Priority = "Medium";
                    }   
                    else if(IconName == "wizard" || IconName == "6" || IconName == "7")
                    {
                        Priority = "High";
                    }
                    else if (IconName == "rose")
                    {
                        Priority = "bellaMini";
                    }
                    else if (IconName == "kingkong")
                    {
                        Priority = "kingkongmini";
                    }
                    else if (IconName == "alice")
                    {
                        Priority = "alicemini";
                    }
                }
                else
                {
                    break;
                }
            }
        }
            if (streak > 2)
            {
                sp.enabled = true;
                Effect.SetActive(false);
                Effect.SetActive(true);
                ZombieGameManager.win = 1;
                Invoke("newanimation", 3f);
            }

        if (streak > 2)
        {
            if (Priority == "Low")
            {
                ZombieGameManager.winamount += (0.1f*streak)+wildpoints;
                Debug.Log("Low "+ZombieGameManager.winamount);
            }
            if (Priority == "Medium")
            {
                ZombieGameManager.winamount += (0.3f * streak) + wildpoints;
                Debug.Log("Medium " + ZombieGameManager.winamount);
            }
            if (Priority == "High")
            {
                ZombieGameManager.winamount += (0.5f * streak) + wildpoints;
                Debug.Log("High " + ZombieGameManager.winamount);
            }
            if (Priority == "bellaMini")
            {
                ZombieGameManager.winamount += (0.5f * streak) + wildpoints;
                kingkong.SetActive(true);
                minigamesound.Play();
                Invoke("bellamini", 2.5f);
            }
            if (Priority == "alicemini")
            {
                ZombieGameManager.winamount += (0.5f * streak) + wildpoints;
                kingkong.SetActive(true);
                minigamesound.Play();
                Invoke("alicemini", 2.5f);
            }
            if (Priority == "kingkongmini")
            {
                ZombieGameManager.winamount += (0.5f * streak) + wildpoints;
                kingkong.SetActive(true);
                ZombieGameManager.kingkong = 1;
                if (streak == 3)
                {
                    ZombieGameManager.king10 = 1;
                }
                if (streak == 4)
                {
                    ZombieGameManager.king10 = 0;
                    ZombieGameManager.king15 = 1;
                }
                Invoke("kingkonghide", 3f);
                Priority = "";
            }
        }
        Invoke("hide", 3f);
    }
    void kingkonghide()
    {
        kingkong.SetActive(false);
       
    }
    void bellamini()
    {
        BellaMini.timer = 30;
        SceneManager.LoadScene(12);
    }
    void alicemini()
    {
        SceneManager.LoadScene(15);
    }
    void hide()
    {
        withwild = false;
        wildpoints = 0;
        streak = 1;
    }
    void newanimation()
    {
        lineanim.SetBool(animationname, true);
        Invoke("hidesp", 5f);
    }
    void hidesp()
    {
        sp.enabled = false;
    }
}
