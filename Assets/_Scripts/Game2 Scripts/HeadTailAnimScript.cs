using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeadTailAnimScript : MonoBehaviour
{
    public static HeadTailAnimScript instance;
    Animator anim;
    public TextMeshProUGUI headTailAnimTxt;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        anim = GetComponent<Animator>();
    }

    public void PlayHeadTailAnimation()
    {
        anim.SetBool("IsHeadTail", true);
        StartCoroutine(waitFunc());
    }

    private IEnumerator waitFunc()
    {
        yield return new WaitForSeconds(2.5f);
        anim.SetBool("IsHeadTail", false);
    }
}
