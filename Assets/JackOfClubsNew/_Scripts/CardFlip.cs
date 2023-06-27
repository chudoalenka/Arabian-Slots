using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public Animator cardanim;
    int onetime = 0;
    private void Update()
    {
        if (BellaMini.villan==1&&onetime==0)
        {
            
            BellaMini.audioplay = 1;
            BellaMini.streak = 0;
            Invoke("idle", 1f);
            onetime = 1;
        }
        //if (BellaMini.streak == 2)
        //{
        //    if (BellaMini.previouscard == BellaMini.whichcard)
        //    {
        //        BellaMini.whichcard = -1;
        //        Invoke("idle", 1f);
        //        BellaMini.streak = 1;
        //    }
        //    if (BellaMini.whichcard != 1 || BellaMini.whichcard != 2)
        //    {
        //        BellaMini.whichcard = -1;
        //        Invoke("idle", 1f);
        //        BellaMini.streak = 1;
        //    }
        // }
    }
    public void OnClick(int no)
    {
        cardanim.SetBool("flip", true);
        cardanim.SetBool("idle", false);
        if (no == 1 || no == 2)
        {
            BellaMini.whichcard = no;
            BellaMini.villan = 0;
            onetime = 0;
            BellaMini.streak++;
            BellaMini.resultupdate();
            
        }
        else if(no==5)
        {
            BellaMini.alicewin = 1;
        }
        else 
        {
            BellaMini.whichcard = 0; BellaMini.previouscard = 0;
            BellaMini.villan = 1;
            onetime = 0;
            BellaMini.audioplay = 1;
            BellaMini.streak = 0;
            Invoke("idle", 1f);
        }     
    }
    void idle()
    {
        cardanim.SetBool("flip", false);
        cardanim.SetBool("idle", true);
    }
}
