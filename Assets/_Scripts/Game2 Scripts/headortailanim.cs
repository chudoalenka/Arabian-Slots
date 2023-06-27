using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headortailanim : MonoBehaviour
{
    public Animator anim1,anim2;
   public void onpress()
    {
        anim1.enabled = false;
        anim2.enabled = false;
    }
    private void OnEnable()
    {
        anim1.enabled = true;
        anim2.enabled = true;
    }
}
